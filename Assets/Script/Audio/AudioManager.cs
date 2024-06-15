using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour, IDataPersistence
{
    public static AudioManager Instance { get; private set; }

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private Slider sfxSlider, bgmSlider;

    public void LoadData(GameData data)
    {
        this.bgmSlider.value = data.SliderValue;
        this.sfxSlider.value = data.SliderValueSFX;
    }

    public void SaveData(GameData data)
    {
        data.SliderValue = this.bgmSlider.value;
        data.SliderValueSFX = this.sfxSlider.value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        sfxSlider = GameObject.FindGameObjectWithTag("SliderSFX").GetComponent<Slider>();
        bgmSlider = GameObject.FindGameObjectWithTag("SliderBGM").GetComponent<Slider>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        musicSource.volume = bgmSlider.value;
        sfxSource.volume = sfxSlider.value;
    }


    public void PlayMusic(string name)
    {
        Sound findMusic = Array.Find(musicSounds, x=> x.name == name);
        
        if (findMusic == null)
        {
            Debug.LogError("No music with that name on AudioManager");
        }
        else
        {
            musicSource.clip = findMusic.clip;
            musicSource.Play();
        }
    }
    public void PlaySoundEffect(string name)
    {
        Sound findSoundEffect = Array.Find(sfxSounds, x => x.name == name);

        if (findSoundEffect == null)
        {
            Debug.LogError("No music with that name on AudioManager");
        }
        else
        {
            sfxSource.PlayOneShot(findSoundEffect.clip);
        }
    }
}
