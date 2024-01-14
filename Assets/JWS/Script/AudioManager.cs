using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using UnityEngine.Rendering;

[Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public Sound[] musicSound;
    public Sound[] sfxSound;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider sfxSlider;


    public GameObject AudioOptionPanel;
    public bool IsAudioPanel = false;

    const string MIXER_MUSIC = "Music";
    const string MIXER_SFX = "Sfx";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicSlider.value = 1.0f;
        sfxSlider.value = 1.0f;

        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSfxVolume);
    }

    void ChangeMusicVolume(float value)
    {
        if (value > 0)
        {
            mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        }
        else
        {
            mixer.SetFloat(MIXER_MUSIC, -80); // 또는 다른 값으로 설정
        }
    }

    void ChangeSfxVolume(float value)
    {
        if (value > 0)
        {
            mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        }
        else
        {
            mixer.SetFloat(MIXER_SFX, -80); // 또는 다른 값으로 설정
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSound, x => x.name == name);

        if(sound == null)
        {
            Debug.Log("SondNotFound_ERROR");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(musicSound, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("SondNotFound_ERROR");
        }
        else
        {
            sfxSource.clip = sound.clip;
            sfxSource.Play();
        }
    }

    public void AudioOption_On_Off(bool type)
    {
        IsAudioPanel = type;
        AudioOptionPanel.SetActive(type);
    }
}
