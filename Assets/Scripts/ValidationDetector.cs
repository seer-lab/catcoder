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
    [SerializeField] private GameObject progressPanel;
    [SerializeField] private Image mask;

    [SerializeField] BoolAssetValue stageCompletion2;
    [SerializeField] BoolAssetValue stageCompletion3;

    private int hqItemCounter;
    private int mqItemCounter;

    //Detect when an object enters the collider
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CatPostHeld" && !other.isTrigger)
        {
            itemPlaced = other.gameObject;
            other.transform.position = placeSpot.position;
            other.transform.parent = transform;
            other.gameObject.layer = 7;

            if (thisStage.currentStage == StageValues.stage2)
            {
                //Logic for what to do in phase 2
                if(itemPlaced.name == "CatPost HQ(Clone)")
                {
                    hqItemCounter++;
                }
                if (hqItemCounter == stage.stage1noHQ)
                {
                    //Set completion flag for stage, this will need a boolean scriptable object on each detector,
                    //and another script should take in both booleans SO's and check if they are both true, if this
                    //passes, than the stage with change to stage 2a
                    stageCompletion2.value = true;
                }
            }
            if (thisStage.currentStage == StageValues.stage3)
            {
                //Logic for what to do in phase 3
                if (itemPlaced.name == "CatPost HQ(Clone)")
                {
                    hqItemCounter++;
                }
                if (itemPlaced.name == "CatPost MQ(Clone)")
                {
                    mqItemCounter++;
                }

                if (hqItemCounter == stage.stage2noHQ && mqItemCounter == stage.stage2noMQ)
                {
                    stageCompletion3.value = true;
                }
            }
        }
    }
}
