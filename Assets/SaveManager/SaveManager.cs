using System.IO;
using UnityEngine;

public static class SaveManager
{
	private static readonly string settingsFilePath = Path.Combine(Application.persistentDataPath, "SaveFile.json");

	public static void SaveSettings(GameSettings gameSettings)
	{
		try
		{
			string settingsJson = JsonUtility.ToJson(gameSettings, true); // Pretty print for readability
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
				Debug.LogWarning("Settings file not found. Returning default settings.");
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
			Debug.LogWarning("No settings file found to delete.");
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

