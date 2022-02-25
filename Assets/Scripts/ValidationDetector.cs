using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidationDetector : MonoBehaviour
{
    [SerializeField] Transform placeSpot;
    private GameObject itemPlaced;

    [SerializeField] StageClassAssetValue stage;
    [SerializeField] DialogueStateAssetValue thisStage;

    [SerializeField] private GameObject popupPanel;

    [SerializeField] BoolAssetValue stageCompletion2;
    [SerializeField] BoolAssetValue stageCompletion3;

    [SerializeField] private GameObject hqProgressPanels;
    [SerializeField] private GameObject mqProgressPanels;
    [SerializeField] private Image maskHq;
    [SerializeField] private Image maskMq;

    private int hqItemCounter;
    private int mqItemCounter;

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

            if (thisStage.currentStage == StageValues.stage2)
            {
                //Enable HQ Panels
                hqProgressPanels.SetActive(true);

                //Logic for what to do in phase 2
                if (itemPlaced.name == "CatPost HQ(Clone)")
                {
                    hqItemCounter++;
                    Debug.Log(stage.stage1noHQ);
                    ProgressBar.GetCurrentFill(maskHq, hqProgressPanels, 0, stage.stage1noHQ, hqItemCounter);
                    Debug.Log(hqItemCounter);
                }
                if (hqItemCounter >= stage.stage1noHQ)
                {
                    //Set completion flag for stage, this will need a boolean scriptable object on each detector,
                    //and another script should take in both booleans SO's and check if they are both true, if this
                    //passes, than the stage with change to stage 2a
                    stageCompletion2.value = true;
                    hqItemCounter = 0;
                }
            }
            if (thisStage.currentStage == StageValues.stage3)
            {
                //Enable HQ Panels
                hqProgressPanels.SetActive(true);
                //Enable MQ Panels
                mqProgressPanels.SetActive(true);

                //Logic for what to do in phase 3
                if (itemPlaced.name == "CatPost HQ(Clone)")
                {
                    hqItemCounter++;
                    ProgressBar.GetCurrentFill(maskHq, hqProgressPanels, 0, stage.stage2noHQ, hqItemCounter);
                }
                if (itemPlaced.name == "CatPost MQ(Clone)")
                {
                    mqItemCounter++;
                    ProgressBar.GetCurrentFill(maskMq, mqProgressPanels, 0, stage.stage2noMQ, mqItemCounter);
                }

                if (hqItemCounter >= stage.stage2noHQ && mqItemCounter >= stage.stage2noMQ)
                {
                    stageCompletion3.value = true;
                    hqItemCounter = 0;
                    mqItemCounter = 0;
                }
            }
        }
    }
}
