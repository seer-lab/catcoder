using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DialogueNPC2 : Interactable
{
    [SerializeField] private TextAssetValue dialogueValue; //intermediate dialogue value
    [SerializeField] private TextAsset[] myDialogue; // npcs dialogue
    [SerializeField] private Notification scrollingDialogueNotification;

    [SerializeField] BoolAssetValue isSpeaking;

    [SerializeField] TileBase tile;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Vector3Int cell;
    [SerializeField] DialogueStateAssetValue thisStage;

    [SerializeField] private CompletionCheck isCompleted;

    // Start is called before the first frame update
    void Start()
    {
        isSpeaking.value = false;
        thisStage.currentStage = StageValues.stage0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if(isSpeaking.value == false)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    isSpeaking.value = true;

                    //IF-ELSE Logic for stages to set correct dialogue
                    if(thisStage.currentStage == StageValues.stage0)
                    {
                        //First dialogue and phase 1
                        UseDialogue(0);

                        //Lock area after dialogue starts
                        if (tilemap.HasTile(cell) == false)
                        {
                            tilemap.SetTile(cell, tile);
                        }
                        thisStage.currentStage = StageValues.stage1;
                    }
                    if(thisStage.currentStage == StageValues.stage1a)
                    {
                        //Post emergency stop, pre phase 2
                        UseDialogue(1);

                        //Begin phase 2
                        thisStage.currentStage = StageValues.stage2;
                    }
                    if(thisStage.currentStage == StageValues.stage2a)
                    {
                        //Post phase 2, pre phase 3
                        UseDialogue(2);

                        //Begin phase 3
                        thisStage.currentStage = StageValues.stage3;
                    }
                    if(thisStage.currentStage == StageValues.stage3a)
                    {
                        //Post phase 3
                        UseDialogue(3);

                        thisStage.currentStage = StageValues.stage4;
                    }
                    if(thisStage.currentStage == StageValues.stage5)
                    {
                        //Unblock area
                        if (tilemap.HasTile(cell) == true)
                        {
                            tilemap.SetTile(cell, null);
                            isCompleted.level2Completion = true;
                        }
                    }
                    
                }
            }
        }
    }

    void UseDialogue(int gotoStage)
    {
        //Play dialogue from array
        dialogueValue.value = myDialogue[gotoStage]; //0 for now due to absence of logic
        scrollingDialogueNotification.Raise();
    }
}
