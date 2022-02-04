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

    // Start is called before the first frame update
    void Start()
    {
        isSpeaking.value = false;
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
                }
            }
        }
    }

    void UseDialogue()
    {
        //Play dialogue from array
        dialogueValue.value = myDialogue[0]; //0 for now due to absence of logic
        scrollingDialogueNotification.Raise();
    }
}
