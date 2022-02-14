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
        stage1noHQ = Random.Range(5, 10);
        stage1noMQ = 0;
        stage1forLen = 0;

        //Stage 2
        stage2noHQ = Random.Range(5, 10);
        stage2noMQ = Random.Range(5, 10);
        stage2forLen = Random.Range(40, 50);

        Debug.Log("Start done");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Stage 1
                stageToInfo.stage1noHQ = stage1noHQ;
                stageToInfo.stage1noMQ = stage1noMQ;
                stageToInfo.stage1forLen = stage1forLen;

                //Stage 2
                stageToInfo.stage2noHQ = stage2noHQ;
                stageToInfo.stage2noMQ = stage2noMQ;
                stageToInfo.stage2forLen = stage2forLen;

                stageGeneral = stageToInfo;

                infoDialogueNotification.Raise();
            }
        }
    }

    
}
