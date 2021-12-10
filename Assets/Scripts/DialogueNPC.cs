using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNPC : Interactable
{
    [SerializeField] private TextAssetValue dialogueValue; //intermediate dialogue value
    [SerializeField] private TextAsset myDialogue; // npcs dialogue
    [SerializeField] private Notification branchingDialogueNotification;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKey(KeyCode.R))
            {
                dialogueValue.value = myDialogue;
                branchingDialogueNotification.Raise();
            }
        }
    }

    //function to show the dialogue
    //
}
