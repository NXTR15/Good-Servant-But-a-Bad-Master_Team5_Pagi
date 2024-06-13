using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float TimeRemaining;
    public float SliderValue;
    public float SliderValueSFX;
    public SerializableDictionary<string, bool> doorOpened;

    public GameData()
    {
        this.TimeRemaining = 300;
        this.SliderValue = 1f;
        this.SliderValueSFX = 1f;
        doorOpened = new SerializableDictionary<string, bool>();
    }
}
