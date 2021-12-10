using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class NpcDialogueController : MonoBehaviour
{
    [SerializeField] private GameObject branchingCanvas;
    [SerializeField] private TextAssetValue dialogueValue;

    [SerializeField] private Story myStory;

    public DialogueObject printedDialogue;

    public int clickedIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableCanvas()
    {
        branchingCanvas.SetActive(true);
        SetStory();
        RefreshView();
    }

    public void SetStory()
    {
        if (dialogueValue.value)
        {
            myStory = new Story(dialogueValue.value.text);
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }

    public void RefreshView()
    {
        while (myStory.canContinue)
        {
            MakeNewDialogue(myStory.Continue());
        }
        branchingCanvas.SetActive(false);       
    }

    public void MakeNewDialogue(string newDialogue)
    {

        DialogueObject newDialogueObject = printedDialogue.GetComponent<DialogueObject>();
        newDialogueObject.Setup(newDialogue);

    }
}
