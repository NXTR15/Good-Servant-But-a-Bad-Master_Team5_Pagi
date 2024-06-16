using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    // UI Text components for the sentence and speaker name
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    // Play the specified story scene
    public void PlayScene(StoryScene scene)
    {
        Debug.Log("Playing scene: " + scene.name);

        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    // Play the next sentence in the current scene
    public void PlayNextSentence()
    {
        if (currentScene != null && sentenceIndex + 1 < currentScene.sentences.Count)
        {
            var sentence = currentScene.sentences[++sentenceIndex];

            // Check if the sentence starts with "/" and remove "/"
            bool isItalic = false;
            if (sentence.text.StartsWith("/"))
            {
                sentence.text = sentence.text.Substring(1);  // Remove "/" from the text
                isItalic = true;
            }

            StartCoroutine(TypeText(sentence.text, isItalic));
            personNameText.text = sentence.speaker.speakerName;
            personNameText.color = sentence.speaker.textColor;
        }
    }

    // Check if the text typing is completed
    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    // Check if the current sentence is the last one in the scene
    public bool IsLastSentence()
    {
        if (currentScene != null)
        {
            return sentenceIndex + 1 == currentScene.sentences.Count;
        }
        else
        {
            Debug.LogWarning("Current scene is null!");
            return true;
        }
    }

    // Coroutine to type the text letter by letter
    private IEnumerator TypeText(string text, bool isItalic)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        // Apply italic style if needed
        if (isItalic)
        {
            barText.fontStyle = FontStyles.Italic;
        }
        else
        {
            barText.fontStyle = FontStyles.Normal;
        }

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
