using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject
{
    // List of sentences in the story scene
    public List<Sentence> sentences;
    // Background sprite for the scene
    public Sprite background;
    // Position of the background
    public Vector2 backgroundPosition;
    // Reference to the next scene
    public StoryScene nextScene;

    [System.Serializable]
    public struct Sentence
    {
        // Text of the sentence
        public string text;
        // Speaker of the sentence
        public Speaker speaker;
    }
}
