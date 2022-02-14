using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SceneBuilder : MonoBehaviour
{
    private float nextActionTime = 4f;
    private float period = 4f;
    private int postNo = 5;
    [SerializeField] DialogueStateAssetValue thisStage;
    [SerializeField] private GameObject[] catPost;

    [SerializeField] BoolAssetValue stageCompletion2a;
    [SerializeField] BoolAssetValue stageCompletion2b;
    [SerializeField] BoolAssetValue stageCompletion3a;
    [SerializeField] BoolAssetValue stageCompletion3b;

    // Start is called before the first frame update
    void Start()
    {
        stageCompletion2a.value = false;
        stageCompletion2b.value = false;
        stageCompletion3a.value = false;
        stageCompletion3b.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] posts = GameObject.FindGameObjectsWithTag("CatPostMoving");

        if (thisStage.currentStage == StageValues.stage1)
        {
            postNo = 10;
            period = 1f;
        }
        else if (thisStage.currentStage == StageValues.stage2)
        {
            postNo = 5;
            period = 4f;
        }
        else if (thisStage.currentStage == StageValues.stage3)
        {
            postNo = 1;
            period = 2f;
        }

        if (posts.Length < postNo)
        {

            if (Time.time > nextActionTime)
            {
                //Debug.Log("next action1: " + nextActionTime);
                nextActionTime = Time.time + period;
                //Debug.Log("next action2: " + nextActionTime);
                Debug.Log("spawning one");
                SpawnRandomByPercentage();
            }
        }


        //Progression for completion checks
        if (thisStage.currentStage == StageValues.stage2)
        {
            if (stageCompletion2a.value == true && stageCompletion2b.value == true)
            {
                //Set stage to 2a
                thisStage.currentStage = StageValues.stage2a;
            }
        }

        if (thisStage.currentStage == StageValues.stage3)
        {
            if (stageCompletion3a.value == true && stageCompletion3b.value == true)
            {
                //Set stage to 3a
                thisStage.currentStage = StageValues.stage3a;
            }
        }
    }
    private void SpawnRandomByPercentage()
    {
        int randomPercentage = Random.Range(1, 100);

        //Phase 1
        if (thisStage.currentStage == StageValues.stage1)
        {
            //Debug.Log("spawning");
            Instantiate(catPost[0]);
        }

        //Phase 2
        else if (thisStage.currentStage == StageValues.stage2)
        {
            if (randomPercentage >= 1 && randomPercentage <= 70)
            {
                Instantiate(catPost[0]);
            }
            else if (randomPercentage >= 71 && randomPercentage <= 100)
            {
                Instantiate(catPost[1]);
            }
        }

        //Phase 3
        else if (thisStage.currentStage == StageValues.stage3)
        {
            if (randomPercentage >= 1 && randomPercentage <= 70)
            {
                Instantiate(catPost[0]);
            }
            else if (randomPercentage >= 71 && randomPercentage <= 90)
            {
                Instantiate(catPost[1]);
            }
            else if (randomPercentage >= 91 && randomPercentage <= 100)
            {
                Instantiate(catPost[2]);
            }
        }

        //Post phase to spawn legendary cat post
        else if (thisStage.currentStage == StageValues.stage4)
        {
            Instantiate(catPost[3]);
        }
    }
}
