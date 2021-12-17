using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class NpcDialogueController : MonoBehaviour
{
    [SerializeField] private GameObject scrollingCanvas;
    [SerializeField] private TextAssetValue dialogueValue;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private Story myStory;

    public DialogueObject printedDialogue;

    private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            RefreshView();
        }
    }

    public void EnableCanvas()
    {
        scrollingCanvas.SetActive(true);
        SetStory();
        InitialDialogue();
    }

    public void SetStory()
    {
        if (dialogueValue.value)
        {
            isPlaying = true;
            myStory = new Story(dialogueValue.value.text);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }

    public void RefreshView()
    {
        
        Debug.Log("Should happen once per click");

        if (myStory.canContinue)
        {
            MakeNewDialogue(myStory.Continue());
        }
        else
        {
            isPlaying = false;
            scrollingCanvas.SetActive(false);
            dialogueText.text = "";

        }

    }

    public void InitialDialogue()
    {
        MakeNewDialogue(myStory.Continue());
    }

    public void MakeNewDialogue(string newDialogue)
    {

        DialogueObject newDialogueObject = printedDialogue.GetComponent<DialogueObject>();
        newDialogueObject.Setup(newDialogue);

    }
}
