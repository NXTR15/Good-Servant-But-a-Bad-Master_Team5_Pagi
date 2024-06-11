using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float TimeRemaining;
    public float ScoreInMinigames;
    public Dictionary<string, bool> sceneIsFinished;

    public GameData()
    {
        this.TimeRemaining = 90;
        this.ScoreInMinigames = 0;
        sceneIsFinished = new Dictionary<string, bool>();
    }
}
