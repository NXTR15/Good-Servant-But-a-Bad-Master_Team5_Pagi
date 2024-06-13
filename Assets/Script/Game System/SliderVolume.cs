using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Slider slider;
    private AudioSource audioSource;

    public void LoadData(GameData data)
    {
        this.slider.value = data.SliderValue;
    }

    public void SaveData(GameData data)
    {
        data.SliderValue = this.slider.value;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        audioSource.Play();
    }

    private void Update()
    {
        audioSource.volume = slider.value;
    }
}
