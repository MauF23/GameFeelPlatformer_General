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
		gameSettings = SaveManager.LoadSettings();

        if(gameSettings == null)
        {
            gameSettings = new GameSettings(1, "Player", true);
        }

        ReflectSettings();

	}

    public void SetVolume(float volume)
    {
        gameSettings.volume = volume;
        SaveSettings();
	}

	public void SetVFX(bool sfxToggle)
    {
        gameSettings.vfxToggle = sfxToggle;
        SaveSettings();

	}

	public void SetPlayerName(string name)
    {
        gameSettings.playerName = name;
    }

    public void SaveSettings()
    {
        SaveManager.SaveSettings(gameSettings);
	}

    private void ReflectSettings()
    {
        volumeSlider.value = gameSettings.volume;
		vfxToggle.isOn = gameSettings.vfxToggle;
		inputFieldPlayerName.text = gameSettings.playerName;
	}

}
