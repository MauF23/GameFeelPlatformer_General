using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
	public Sound[] soundList;
	void Awake()
	{
		for (int i = 0; i < soundList.Length; i++)
		{
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			soundList[i].SetSource(audioSource);
		}
	}

	public void PlayAudio(string name)
	{
		for (int i = 0; i < soundList.Length; i++)
		{
			if (name == soundList[i].audioName)
			{
				soundList[i].Play();
				break;
			}
		}
	}

	public void StopAudio(string name)
	{
		for (int i = 0; i < soundList.Length; i++)
		{
			if (name == soundList[i].audioName)
			{
				soundList[i].Stop();
				break;
			}
		}
	}

	public void FadePlayAudio(string name, float fadeTime)
	{
		for (int i = 0; i < soundList.Length; i++)
		{
			if (name == soundList[i].audioName)
			{
				soundList[i].PlayFade(fadeTime);
				break;
			}
		}
	}
}




[System.Serializable]
public class Sound
{
	public string audioName;
	public AudioClip audioClip;

	[Range(0, 1)]
	public float volume;

	[Range(-3, 3)]
	public float pitch;

	public bool loop, playOnAwake;

	public AudioMixerGroup outputMixer;

	private AudioSource audioSource;

	public void SetSource(AudioSource source)
	{
		audioSource = source;

		audioSource.clip = audioClip;
		audioSource.volume = volume;
		audioSource.pitch = pitch;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;

		if (outputMixer != null)
		{
			audioSource.outputAudioMixerGroup = outputMixer;
		}
	}

	public void Play()
	{
		audioSource?.Play();
	}

	public void PlayFade(float fadeTime)
	{
		audioSource.Stop();
		audioSource.volume = 0;

		audioSource.Play();
		audioSource.DOFade(volume, fadeTime);

		//Hint para FadeStop
		//audioSource.DOFade(volume, fadeTime).OnComplete(Stop);
	}

	public void Stop()
	{
		audioSource?.Stop();
	}
}
