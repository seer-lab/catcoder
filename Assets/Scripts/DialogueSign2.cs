using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSign2 : Interactable
{
    [SerializeField] private Notification infoDialogueNotification;
    [SerializeField] private GameObject popupPanel;

    [SerializeField] StageClassAssetValue stageToInfo;
    [SerializeField] StageClassAssetValue stageGeneral;

    private int stage1noHQ;
    private int stage1noMQ;
    private int stage1forLen;
    private int stage2noHQ;
    private int stage2noMQ;
    private int stage2forLen;

    private void Start()
    {
        //Stage 1
        stage1noHQ = Random.Range(4, 8);
        stage1noMQ = 0;
        stage1forLen = 0;

        //Stage 2
        stage2noHQ = Random.Range(1, 5);
        stage2noMQ = Random.Range(1, 3);
        stage2forLen = Random.Range(20, 30);


        /*
        stageToInfo.stage1noHQ = 0;
        stageToInfo.stage1noMQ = 0;
        stageToInfo.stage1forLen = 0;
        stageToInfo.stage2noHQ = 0;
        stageToInfo.stage2noMQ = 0;
        stageToInfo.stage2forLen = 0;

        stageGeneral.stage1noHQ = 0;
        stageGeneral.stage1noMQ = 0;
        stageGeneral.stage1forLen = 0;
        stageGeneral.stage2noHQ = 0;
        stageGeneral.stage2noMQ = 0;
        stageGeneral.stage2forLen = 0;
        */
        Debug.Log("Start done");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("TEST");
                //Stage 1
                stageToInfo.stage1noHQ = stage1noHQ;
                stageToInfo.stage1noMQ = stage1noMQ;
                stageToInfo.stage1forLen = stage1forLen;

                //Stage 2
                stageToInfo.stage2noHQ = stage2noHQ;
                stageToInfo.stage2noMQ = stage2noMQ;
                stageToInfo.stage2forLen = stage2forLen;

                //Set the stages of general equal to stage info
                stageGeneral.stage1noHQ = stageToInfo.stage1noHQ;
                stageGeneral.stage1noMQ = stageToInfo.stage1noMQ;
                stageGeneral.stage1forLen = stageToInfo.stage1forLen;
                stageGeneral.stage2noHQ = stageToInfo.stage2noHQ;
                stageGeneral.stage2noMQ = stageToInfo.stage2noMQ;
                stageGeneral.stage2forLen = stageToInfo.stage2forLen;

                Debug.Log("stage is: " + stageGeneral.stage1noHQ);

                infoDialogueNotification.Raise();
            }
        }
    }

    
}
