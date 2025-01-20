using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    GameSettings gameSettings;
    public Slider volumeSlider;
    public Toggle vfxToggle;
    public TMP_InputField inputFieldPlayerName;

    void Start()
    {
	}

    public void SetVolume(float volume)
    {
        gameSettings.volume = volume;
	}

	public void SetVFX(bool sfxToggle)
    {
        gameSettings.vfxToggle = sfxToggle;

	}

	public void SetPlayerName(string name)
    {
        gameSettings.playerName = name;
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

	/*
	JSON snippet

    //Save
    try
		{
			ScoreContainer scoreContainer = new ScoreContainer(scoreList);
			string json = JsonUtility.ToJson(scoreContainer);
			PlayerPrefs.SetString($"{scoreKey}", json);
			PlayerPrefs.Save();
			Debug.Log($"<color=cyan>SaveScore</color>");
		}
		catch (System.Exception e)
		{
			Debug.LogError($"<color=red>Error saving score: {e.Message}</color>");
		}

    Load
    //	return JsonUtility.FromJson<ScoreContainer>(scorePath).scoreList;
    */



}
