using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSign : Interactable
{
    [SerializeField] private TextAssetValue dialogueValue; //intermediate dialogue value
    [SerializeField] private TextAsset myDialogue; // sign dialogue
    [SerializeField] private Notification branchingDialogueNotification;

    [SerializeField] private ItemDetector myBowlType; //ADDED
    [SerializeField] private ObjectValue bowlType; //ADDED

    [SerializeField] private ItemDetector myFromObject; //ADDED
    [SerializeField] private ItemDetectorValue fromObject; //ADDED

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
                bowlType.value = myBowlType.itemPlaced; //ADDED
                fromObject.value = myFromObject;
                dialogueValue.value = myDialogue;
                branchingDialogueNotification.Raise();
            }
        }
    }
}
