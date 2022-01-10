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

    private int currentScore;

    [SerializeField] private GameObject popupPanel;

    [SerializeField] private GameObject progressPanel;
    [SerializeField] private Image mask;


    //Progression
    private bool thirdPhase = true;
    [SerializeField] BoolAssetValue[] stageValues;
    [SerializeField] BoolAssetValue[] stageCompleted;
    [SerializeField] BoolAssetValue[] spawnSpecial;
    int progressionCounter;

    public int clickedIndex;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("when is this called?");
        stageCompleted[0].value = true;
        stageValues[1].value = true;
        Debug.Log("here its true:" + stageValues[1].value);

        Debug.Log("stage0 is : " + stageValues[0].value);
        Debug.Log("stage1 is : " + stageValues[1].value);
        Debug.Log("stage2 is : " + stageValues[2].value);
        Debug.Log("stage3 is : " + stageValues[3].value);
        Debug.Log("stage4 is : " + stageValues[4].value);
        Debug.Log("stage5 is : " + stageValues[5].value);
        Debug.Log("stage6 is : " + stageValues[6].value);
        Debug.Log("stage7 is : " + stageValues[7].value);
        Debug.Log("stage8 is : " + stageValues[8].value);
    }

    // Update is called once per frame
    void Update()
    {
        if (stageValues[5].value == true && stageCompleted[4].value == true)
        {
            progressPanel.SetActive(true);
        }
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
        DialogueObject newDialogueObject = printedDialogue.GetComponent<DialogueObject>();
        newDialogueObject.Setup(fromObjectValue.value.GetComponentInChildren<TextMeshPro>().text);
    }

    public void MakeNewChoices()
    {
        for(int i=0; i < choiceHolder.transform.childCount; i++)
        {
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
        //WORKS
        //stageValues[0].value = false;
        //stageValues[1].value = true;
        //stageValues[4].value = false;

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
            ContinueProgression();
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen bool!");
            CorrectlyChosenResponse("Correctly chosen boolean!", true);
        }
        else if (choice == 1 && bowlValue.value.name == "BowlChar(Clone)")
        {
            Debug.Log("stage1 is : " + stageValues[1].value);
            Debug.Log("comp0 is : " + stageCompleted[0].value);

            if (stageValues[1].value == true && stageCompleted[0].value == true)
            {
                Debug.Log("Stage 1 should be completed");
                stageCompleted[1].value = true;
                stageCompleted[0].value = false;

            }

            ContinueProgression();
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen char!");
            CorrectlyChosenResponse("Correctly chosen string!", true);
        }
        else if (choice == 2 && bowlValue.value.name == "BowlFloat(Clone)")
        {
            ContinueProgression();
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen float!");
            CorrectlyChosenResponse("Correctly chosen float!", true);
        }
        else if (choice == 3 && bowlValue.value.name == "BowlInt(Clone)")
        {
            ContinueProgression();
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, true);
            Debug.Log("Correctly chosen int!");
            CorrectlyChosenResponse("Correctly chosen integer!", true);
        }
        else
        {
            if (stageValues[1].value == true && stageCompleted[0].value == true)
            {
                Debug.Log("Incorrect stage 1");
                stageValues[3].value = true;
                stageValues[1].value = false;
            }
            fromObjectValue.value.changeObject(fromObjectValue.value.itemPlaced, choice, false);
            Debug.Log("Incorrect! Item is: " + bowlValue.value.name);
            CorrectlyChosenResponse("Incorrect! Item is a " + bowlValue.value.name, false);
            
        }


        clickedIndex = choice;
    }

    public void CorrectlyChosenResponse(string response, bool correctness)
    {
        popupPanel.GetComponentInChildren<TextMeshProUGUI>().text = response;

        PopupPanelController.OpenPopup(popupPanel);
        popupPanel.SetActive(true);
        StartCoroutine(PopupPanelController.PopupAndDelay(5, popupPanel));

        if (stageValues[5].value == true && stageCompleted[4].value == true)
        {
            progressPanel.SetActive(true);
            if (correctness)
            {
                currentScore += 2;
                ProgressBar.GetCurrentFill(mask, progressPanel, 0, 20, currentScore);
            }
            if (!correctness)
            {
                if (currentScore == 0)
                {
                    ProgressBar.GetCurrentFill(mask, progressPanel, 0, 20, currentScore);
                }
                else
                {
                    currentScore -= 1;
                    ProgressBar.GetCurrentFill(mask, progressPanel, 0, 20, currentScore);
                }
            }
            if(currentScore >= 20)
            {
                stageCompleted[5].value = true;
            }
        }
    }

    void ContinueProgression()
    {
        Debug.Log("Stage 4 progression");
        if (stageValues[4].value == true && stageCompleted[1].value == true)
        {
            progressionCounter++;
            if (progressionCounter < 3)
            {
                spawnSpecial[1].value = true;
            }
            else
            {
                Debug.Log("Progression is not yet 3");
                stageCompleted[1].value = false;
                stageCompleted[4].value = true;
            }
        }
    }


}
