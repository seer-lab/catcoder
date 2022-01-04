using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class SignDialogueController : MonoBehaviour
{
    [SerializeField] private GameObject branchingCanvas;
    [SerializeField] private TextAssetValue dialogueValue;

    [SerializeField] private Story myStory;
    [SerializeField] private GameObject choiceHolder;

    //public ItemDetector getBowlType; //ADDED //REMOVED, STATIC OF DETECTOR SPOT
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
        //dialogueText.GetComponent<TextMeshPro>().text = fromObjectValue.value.GetComponentInChildren<TextMeshPro>().text;

        //newDialogueObject.Setup(newDialogue);
        newDialogueObject.Setup("test");
        //dialogueText.GetComponent<TextMeshPro>().text = fromObjectValue.value.GetComponentInChildren<TextMeshPro>().text;
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
        if(fromObjectValue.value.itemPlaced == null)
        {
            Debug.Log("NO BOWL!");
            //UI POPUP?
            return;
        }
        Debug.Log("name on the bowl: " + fromObjectValue.value.GetComponentInChildren<TextMeshPro>().text);
        //dialogueText.GetComponent<TextMeshPro>().text = fromObjectValue.value.GetComponentInChildren<TextMeshPro>().text;
        //Debug.Log("THIS IS THE BEFORE THING: " + getBowlType.itemPlaced.name);
        //Debug.Log("THIS IS THE AFTER THING: " + bowlValue.value.name);
        //Debug.Log("THIS IS THE BEFORE THING: " + getBowlType.name);
        Debug.Log("THIS IS THE AFTER THING: " + fromObjectValue.value.name);
        Debug.Log("this button index was clicked:" + choice);
        //Debug.Log("this is the object bowlvalue: " + bowlValue.value.name);
        Debug.Log("this is the object fromobject val placed name: " + fromObjectValue.value.itemPlaced.name);

        //Debug.Log("Bowl type is: " + getBowlType.itemPlaced.name);

        if (choice == 0 && bowlValue.value.name == "BowlBool(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen bool!");
        }
        else if (choice == 1 && bowlValue.value.name == "BowlChar(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen char!");
        }
        else if (choice == 2 && bowlValue.value.name == "BowlFloat(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen float!");
        }
        else if (choice == 3 && bowlValue.value.name == "BowlInt(Clone)")
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen int!");
        }
        else
        {
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, false);
            Debug.Log("Incorrect! Item is: " + bowlValue.value.name);
        }


        clickedIndex = choice;
    }



}
