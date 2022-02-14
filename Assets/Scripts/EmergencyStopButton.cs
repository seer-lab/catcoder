using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyStopButton : Interactable
{
    [SerializeField] DialogueStateAssetValue thisStage;

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
                //Stop the infinite while loop, and set stage to 2
                if (thisStage.currentStage == StageValues.stage1)
                {
                    Debug.Log("Set stage to 2");
                    thisStage.currentStage = StageValues.stage1a;
                }
                
            }
        }
    }
}
