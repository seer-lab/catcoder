using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class SignDialogueController : MonoBehaviour
{
    [SerializeField] private GameObject branchingCanvas;
    [SerializeField] private TextAssetValue dialogueValue;

    [SerializeField] private Story myStory;
    [SerializeField] private GameObject choiceHolder;

    public ItemDetector getBowlType; //ADDED
    [SerializeField] private ObjectValue bowlValue;
    [SerializeField] private ItemDetectorValue fromObjectValue;

    public List<ButtonObject> buttonList = new List<ButtonObject>();
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
        if(myStory.currentChoices.Count > 0)
        {
            MakeNewChoices();
        }
        else
        {
            branchingCanvas.SetActive(false);
        }
    }

    public void MakeNewResponse(string newDialogue, int choiceValue)
    {
        //ButtonObject newButtonObject = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<ButtonObject>();
        //newButtonObject.Setup(newDialogue, choiceValue);

        buttonList[choiceValue].gameObject.SetActive(true);
        buttonList[choiceValue].Setup(newDialogue, choiceValue);
        Button responseButton = buttonList[choiceValue].gameObject.GetComponent<Button>();
        if (responseButton)
        {
            responseButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); });
            responseButton.onClick.AddListener(delegate { WasClicked(choiceValue); });
        }
    }
    public void MakeNewDialogue(string newDialogue)
    {

        //DialogueObject newDialogueObject = Instantiate(dialoguePrefab, dialogueHolder.transform).GetComponent <DialogueObject>();
        //newDialogueObject.Setup(newDialogue);


        DialogueObject newDialogueObject = printedDialogue.GetComponent<DialogueObject>();
        newDialogueObject.Setup(newDialogue);
        //printedDialogue.gameSetup(newDialogue);
        //printedDialogue.GetComponent<TMPro.TextMeshProUGUI>().text = newDialogue;
        //newDialogueObject.Setup(newDialogue);
    }

    public void MakeNewChoices()
    {
        for(int i=0; i < choiceHolder.transform.childCount; i++)
        {
            //Debug.Log(i);
            //Debug.Log(buttonList[i].gameObject);
            //Destroy(choiceHolder.transform.GetChild(i).gameObject);
            buttonList[i].gameObject.SetActive(false);
        }
        for(int i=0;i<myStory.currentChoices.Count; i++)
        {
            MakeNewResponse(myStory.currentChoices[i].text, i);

        }
    }

    public void ChooseChoice(int choice)
    {
        myStory.ChooseChoiceIndex(choice);
        RefreshView();
    }

    public void WasClicked(int choice)
    {
        //Debug.Log("THIS IS THE BEFORE THING: " + getBowlType.itemPlaced.name);
        //Debug.Log("THIS IS THE AFTER THING: " + bowlValue.value.name);
        Debug.Log("THIS IS THE BEFORE THING: " + getBowlType);
        Debug.Log("THIS IS THE AFTER THING: " + fromObjectValue.value);
        Debug.Log("this button index was clicked:" + choice);
        //Debug.Log("Bowl type is: " + getBowlType.itemPlaced.name);

        if(choice == 0 && bowlValue.value.name == "BucketBlue(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced);
            Debug.Log("Correctly chosen blue!");
        }
        else if (choice == 1 && bowlValue.value.name == "BucketGreen(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced);
            Debug.Log("Correctly chosen green!");
        }
        else if (choice == 2 && bowlValue.value.name == "BucketRed(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced);
            Debug.Log("Correctly chosen red!");
        }
        else if (choice == 3 && bowlValue.value.name == "BucketYellow(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced);
            Debug.Log("Correctly chosen yellow!");
        }
        else
        {
            Debug.Log("Incorrect! Item is: " + bowlValue.value.name);
            //getBowlType.changeObject(getBowlType.itemPlaced);
        }


        clickedIndex = choice;
    }
}
