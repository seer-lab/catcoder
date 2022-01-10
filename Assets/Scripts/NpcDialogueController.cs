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

    //NPC MOVEMENT
/*    [SerializeField] GameObject npc;
    [SerializeField] VectorValue startingPosition;
    Vector3 targetPos;
    Vector3 change;
    bool canMove;*/

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
/*        canMove = false;*/

/*        targetPos.Set((float)-6.5, (float)2.9, 0);
        change = Vector3.zero;
        change.y = 1;*/
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
/*        if (canMove)
        {
            //NPC movement after speech

            Debug.Log("pos before: " + npc.transform.position);
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPos, 4 * Time.fixedDeltaTime);
            Debug.Log("pos after: " + npc.transform.position);
            
            if (npc.transform.position == targetPos)
            {
                Debug.Log("setting false");
                canMove = false;
            }
        }*/
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
/*            canMove = true;*/
            isPlaying = false;
            scrollingCanvas.SetActive(false);
            dialogueText.text = "";

            /*            //NPC movement after speech
                        targetPos.Set((float)-6.5, (float)2.9, 0);
                        //npc.transform.position = startingPosition.initialValue;
                        change = Vector3.zero;
                        change.y = 1;

                        *//*            npc.GetComponent<Rigidbody2D>().MovePosition(
                                        transform.position + change * 4 * Time.fixedDeltaTime
                                        );*//*
                        Debug.Log("pos before: " + npc.transform.position);
                        npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPos, 4 * Time.fixedDeltaTime);
                        Debug.Log("pos after: " + npc.transform.position);*/
            


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
