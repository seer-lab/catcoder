using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNPC : Interactable
{
    [SerializeField] private TextAssetValue dialogueValue; //intermediate dialogue value
    [SerializeField] private TextAsset[] myDialogue; // npcs dialogue
    [SerializeField] private Notification scrollingDialogueNotification;

    [SerializeField] BoolAssetValue[] stageValues;
    [SerializeField] BoolAssetValue[] stageCompleted;
    [SerializeField] BoolAssetValue[] spawnSpecial;

    [SerializeField] GameObject thisNpc;
    [SerializeField] GameObject[] detectors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                /*                Debug.Log("stage0 is : " + stageValues[0].value);
                                Debug.Log("stage1 is : " + stageValues[1].value);
                                Debug.Log("stage2 is : " + stageValues[2].value);
                                Debug.Log("stage3 is : " + stageValues[3].value);
                                Debug.Log("stage4 is : " + stageValues[4].value);
                                Debug.Log("stage5 is : " + stageValues[5].value);
                                Debug.Log("stage6 is : " + stageValues[6].value);
                                Debug.Log("stage7 is : " + stageValues[7].value);
                                Debug.Log("stage8 is : " + stageValues[8].value);*/
                Debug.Log("Are we here after doing it right?");

                if (stageValues[0].value == true && stageCompleted[0].value == false)
                {
                    UseDialogue(0); //Initial first dialogue
                    
                    stageValues[0].value = false;
                    stageValues[1].value = true;
                    stageCompleted[0].value = true;
                }
                else if (stageValues[1].value == true && stageCompleted[0].value == true)
                {
                    UseDialogue(1); //First dialogue in room scene
                    //stageValues[1].value = false;
                    spawnSpecial[0].value = true;
                }
                else if (stageValues[1].value == true && stageCompleted[1].value == true)
                {
                    UseDialogue(2); //Success option for stage 1
                    Debug.Log("Stage 1 success");
                    stageValues[1].value = false;
                    stageValues[4].value = true;

                    //ClEAR THE SCENE OF BOWLS
                    GameObject existingBowls = GameObject.FindGameObjectWithTag("TransformedObjectCorrect");
                    GameObject.Destroy(existingBowls);
                }
                else if (stageValues[3].value == true && stageCompleted[1].value == false)
                {
                    UseDialogue(3); //Failure option for stage 1

                    stageValues[3].value = false;
                    stageValues[1].value = true;

                    //CLEAR THE SCENE OF BOWLS AND RESPAWN
                    spawnSpecial[0].value = true;
                    GameObject existingBowls = GameObject.FindGameObjectWithTag("TransformedObjectIncorrect");
                    GameObject.Destroy(existingBowls);
                }
                else if (stageValues[4].value == true && stageCompleted[1].value == true)
                {
                    Debug.Log("Stage 4");
                    UseDialogue(4); //Second dialogue in room scene
                    spawnSpecial[1].value = true;
                }
                else if (stageValues[4].value == true && stageCompleted[4].value == true)
                {
                    UseDialogue(5); //Success option for stage 4

                    stageValues[4].value = false;
                    stageValues[5].value = true;

                }
/*                else if (stageValues[4].value == true && stageCompleted[4].value == false)
                {
                    UseDialogue(6); //Failure option for stage 4
                }*/
                else if (stageValues[5].value == true && stageCompleted[5].value == true)
                {
                    UseDialogue(7); //Success option for stage 5

                    stageValues[5].value = false;
                }
                else if (stageValues[5].value == true && stageCompleted[5].value == false)
                {
                    UseDialogue(8); //Failure option for stage 5
                }
                else
                {
                    Debug.Log("YOU SHOULDN'T GET HERE!");
                }
            }
        }
    }

    //function to show the dialogue
    void UseDialogue(int gotoStage)
    {
        dialogueValue.value = myDialogue[gotoStage];
        scrollingDialogueNotification.Raise();
    }
}
