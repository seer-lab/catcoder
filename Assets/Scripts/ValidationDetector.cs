using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidationDetector : MonoBehaviour
{
    [SerializeField] Transform placeSpot;
    private GameObject itemPlaced;

    [SerializeField] StageClassAssetValue stageToInfo;
    [SerializeField] DialogueStateAssetValue thisStage;

    [SerializeField] private GameObject popupPanel;

    [SerializeField] BoolAssetValue stageCompletion2;
    [SerializeField] BoolAssetValue stageCompletion3;

    [SerializeField] private GameObject hqProgressPanels;
    [SerializeField] private GameObject mqProgressPanels;
    [SerializeField] private Image maskHq;
    [SerializeField] private Image maskMq;

    private int hqItemCounter1;
    private int hqItemCounter2;
    private int mqItemCounter;

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
        stage2noHQ = Random.Range(3, 5);
        stage2noMQ = Random.Range(1, 3);
        stage2forLen = Random.Range(20, 30);

        stageToInfo.stage1noHQ = 0;
        stageToInfo.stage1noMQ = 0;
        stageToInfo.stage1forLen = 0;

        //Stage 2
        stageToInfo.stage2noHQ = 0;
        stageToInfo.stage2noMQ = 0;
        stageToInfo.stage2forLen = 0;

        //Stage 1
        stageToInfo.stage1noHQ = stage1noHQ;
        stageToInfo.stage1noMQ = stage1noMQ;
        stageToInfo.stage1forLen = stage1forLen;

        //Stage 2
        stageToInfo.stage2noHQ = stage2noHQ;
        stageToInfo.stage2noMQ = stage2noMQ;
        stageToInfo.stage2forLen = stage2forLen;

        Debug.Log("Start done");
    }

    //Detect when an object enters the collider
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CatPostHeld" && !other.isTrigger)
        {

            //Currently locks to single position
            itemPlaced = other.gameObject;
            //other.transform.position = placeSpot.position;
            other.transform.parent = transform;
            other.gameObject.layer = 7;

            //Lock to random position around the placeSpot
            var distance = 1.0f;
            var tolerance = 0.8f;
            var offset = placeSpot.transform.position * distance;
            var position = offset + new Vector3(Random.Range(-tolerance, tolerance), Random.Range(-tolerance, tolerance));

            other.transform.position = position;

            if (thisStage.currentStage == StageValues.stage2 && other.gameObject.name != "CatPost SQ(Clone)")
            {
                //Enable HQ Panels
                //hqProgressPanels.SetActive(true);

                //Logic for what to do in phase 2
                if (itemPlaced.name == "CatPost HQ(Clone)")
                {
                    hqProgressPanels.SetActive(true);
                    hqItemCounter1++;
                    Debug.Log(stageToInfo.stage1noHQ);
                    ProgressBar.GetCurrentFill(maskHq, hqProgressPanels, 0, stageToInfo.stage1noHQ, hqItemCounter1);
                    Debug.Log(hqItemCounter1);
                }
                if (hqItemCounter1 >= stageToInfo.stage1noHQ)
                {
                    //Set completion flag for stage, this will need a boolean scriptable object on each detector,
                    //and another script should take in both booleans SO's and check if they are both true, if this
                    //passes, than the stage with change to stage 2a
                    stageCompletion2.value = true;
                    //hqItemCounter1 = stage.stage1noHQ;
                }
            }
            if (thisStage.currentStage == StageValues.stage3 && other.gameObject.name != "CatPost SQ(Clone)")
            {
                //Enable HQ Panels
                //hqProgressPanels.SetActive(true);
                //Enable MQ Panels
                //mqProgressPanels.SetActive(true);

                //Logic for what to do in phase 3
                if (itemPlaced.name == "CatPost HQ(Clone)")
                {
                    hqProgressPanels.SetActive(true);
                    hqItemCounter2++;
                    ProgressBar.GetCurrentFill(maskHq, hqProgressPanels, 0, stageToInfo.stage2noHQ, hqItemCounter2);
                }
                if (itemPlaced.name == "CatPost MQ(Clone)")
                {
                    mqProgressPanels.SetActive(true);
                    mqItemCounter++;
                    ProgressBar.GetCurrentFill(maskMq, mqProgressPanels, 0, stageToInfo.stage2noMQ, mqItemCounter);
                }

                if (hqItemCounter2 >= stageToInfo.stage2noHQ && mqItemCounter >= stageToInfo.stage2noMQ)
                {
                    stageCompletion3.value = true;
                    //hqItemCounter = stage.stage2noHQ;
                    //mqItemCounter = stage.stage2noMQ;
                }
            }
        }
    }
}
