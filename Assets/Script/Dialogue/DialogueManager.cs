using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SearchService;

public class DialogueManager : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject ContinueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator potraitAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    private static DialogueManager instance;
    private StateMachine playerStatemachine;
    private Animator layoutAnimator;
    private Coroutine displayLineCoroutine;
    private const string Speaker_Tag = "speaker";
    private const string Potrait_Tag = "potrait";
    private const string Layout_Tag = "layout";

    private bool canContinueToNextLine = false;
    private bool isAddingRichTextTag = false;
    public bool isDialoguePlaying { get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 dialogue manager in scene");
        }
        instance = this;
        playerStatemachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);

        //Get layout anim
        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 
            && Input.GetKeyDown(KeyCode.Mouse0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);
        playerStatemachine.enabled = false;

        //reset potrait, layout, speaker
        displayNameText.text = "???";
        potraitAnimator.Play("Default");
        layoutAnimator.Play("right");

        ContinueStory();
    }
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        playerStatemachine.enabled = true;
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //Set Text for current dialogue line
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            //Handle tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        // empty dialogue text
        dialogueText.text = "";
        ContinueIcon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        // Display one at a time
        foreach (char letter in line.ToCharArray())
        {
            // if left click on mouse, skip dialogue to the end
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    dialogueText.text = line;
            //    break;
            //}

            // Check if adding rich text text
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not adding then add next letter
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        ContinueIcon.SetActive(true);
        //Display choices if any
        DisplayChoices();

        canContinueToNextLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //Loop through each tag and handle it
        foreach (string tag in currentTags)
        {
            //Parse tags
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2 ) 
            {
                Debug.LogError("Tag cannot be parsed: " + tag);
                Debug.LogError("Check ink dialogue");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case Speaker_Tag:
                    displayNameText.text = tagValue;
                    Debug.Log("speaker=" + tagValue);
                    break;
                case Potrait_Tag:
                    potraitAnimator.Play(tagValue);
                    Debug.Log("potrait=" + tagValue);
                    break;
                case Layout_Tag:
                    layoutAnimator.Play(tagValue);
                    Debug.Log("layout=" + tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not being handled: " + tag);
                    break;
            }
        }

    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // Make sure to check UI can support how much choices
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given tan UI can support. " +
                "Number of choices given:" + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // Menuju ke choice yang ada di UI support dan hide
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }     
    }
}
