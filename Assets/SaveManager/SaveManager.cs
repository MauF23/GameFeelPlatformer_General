using System.IO;
using UnityEngine;

public static class SaveManager
{
	private const string SAVEFOLDER_NAME = "/Saves/";

	//C:\Users\[Username]\AppData\LocalLow\[CompanyName]\[ProductName] solo Windows.
	private static readonly string settingsFilePath = Path.Combine(Application.persistentDataPath + SAVEFOLDER_NAME, "SaveFile.json");

	public static void SaveSettings(GameSettings gameSettings)
	{
		try
		{
			string settingsJson = JsonUtility.ToJson(gameSettings, true);
			File.WriteAllText(settingsFilePath, settingsJson);
			Debug.Log($"Settings saved to: {settingsFilePath}");
		}
		catch (System.Exception e)
		{
			Debug.LogError($"<color=red>Error saving settings: {e.Message}</color>");
		}
	}

	public static GameSettings LoadSettings()
	{
		try
		{
			if (File.Exists(settingsFilePath))
			{
				string settingsJson = File.ReadAllText(settingsFilePath);
				return JsonUtility.FromJson<GameSettings>(settingsJson);
			}
			else
			{
				Debug.LogWarning("<color=orange>Settings file not found. Returning default settings</color>");
				return null;
			}
		}
		catch (System.Exception e)
		{
			Debug.LogError($"<color=red>Error loading settings: {e.Message}</color>");
			return null;
		}
	}

	public static void DeleteSettings()
	{
		if (File.Exists(settingsFilePath))
		{
			File.Delete(settingsFilePath);
			Debug.Log("Settings file deleted.");
		}
		else
		{
			Debug.LogWarning("<color=orange>No settings file found to delete</color>");
		}
	}
}

[System.Serializable]
public class GameSettings
{
	public float volume;
	public string playerName;
	public bool vfxToggle;

	public GameSettings(float volume, string playerName, bool vfxToggle)
	{
		this.volume = volume;
		this.playerName = playerName;
		this.vfxToggle = vfxToggle;
	}
}

