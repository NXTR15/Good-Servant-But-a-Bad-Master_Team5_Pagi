using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    // Name of the speaker
    public string speakerName;
    // Text color associated with the speaker
    public Color textColor;
}
