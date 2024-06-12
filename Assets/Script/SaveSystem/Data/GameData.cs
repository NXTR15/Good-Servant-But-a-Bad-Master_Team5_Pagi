using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float TimeRemaining;
    public SerializableDictionary<string, bool> doorOpened;

    public GameData()
    {
        this.TimeRemaining = 300;
        doorOpened = new SerializableDictionary<string, bool>();
    }
}
