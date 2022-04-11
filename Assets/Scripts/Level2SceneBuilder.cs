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

    [SerializeField] private GameObject[] progressPanels;

    [SerializeField] private CurrentLevelValue currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel.currentLevel = LevelValues.level1_2;

        stageCompletion2a.value = false;
        stageCompletion2b.value = false;
        stageCompletion3a.value = false;
        stageCompletion3b.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] posts = GameObject.FindGameObjectsWithTag("CatPostMoving");

        if (thisStage.currentStage == StageValues.stage0 || thisStage.currentStage == StageValues.stage1)
        {
            postNo = 10;
            period = 1f;
        }
        else if (thisStage.currentStage == StageValues.stage2)
        {
            postNo = 7;
            period = 2f;
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
            //progressPanel.SetActive(true);

            if (stageCompletion2a.value == true && stageCompletion2b.value == true)
            {
                //TODO: Make sure all objects are gone
                //TODO: Speed up the conveyer to move them off faster
                foreach (GameObject panel in progressPanels)
                {
                    panel.SetActive(false);
                }


                //Set stage to 2a
                thisStage.currentStage = StageValues.stage2a;

                //Clear the validation spot of objects
                GameObject[] existingCatPosts = GameObject.FindGameObjectsWithTag("CatPostHeld");
                foreach (GameObject catPost in existingCatPosts)
                {
                    GameObject.Destroy(catPost);
                }
                GameObject leftoverCatPost = GameObject.FindGameObjectWithTag("CatPostMoving");
                GameObject.Destroy(leftoverCatPost);
            }
        }

        if (thisStage.currentStage == StageValues.stage3)
        {
            //progressPanel.SetActive(true);

            if (stageCompletion3a.value == true && stageCompletion3b.value == true)
            {
                //Make sure all objects are gone
                //Speed up the conveyer to move them off faster
                foreach (GameObject panel in progressPanels)
                {
                    panel.SetActive(false);
                }

                //Set stage to 3a
                thisStage.currentStage = StageValues.stage3a;

                GameObject[] existingCatPosts = GameObject.FindGameObjectsWithTag("CatPostHeld");
                foreach (GameObject catPost in existingCatPosts)
                {
                    GameObject.Destroy(catPost);
                }
            }
        }
    }
    private void SpawnRandomByPercentage()
    {
        int randomPercentage = Random.Range(1, 100);

        //Phase 1
        if (thisStage.currentStage == StageValues.stage0 || thisStage.currentStage == StageValues.stage1)
        {
            //Debug.Log("spawning");
            //catPost[0].layer = 7;

            //TODO: Determine if i need to change the layer mask for the first level OR figure out how to reset first scene
            Instantiate(catPost[0]);
        }

        //Phase 2
        else if (thisStage.currentStage == StageValues.stage2)
        {
            if (randomPercentage >= 1 && randomPercentage <= 50)
            {
                Instantiate(catPost[0]);
            }
            else if (randomPercentage >= 51 && randomPercentage <= 100)
            {
                Instantiate(catPost[1]);
            }
        }

        //Phase 3
        else if (thisStage.currentStage == StageValues.stage3)
        {
            if (randomPercentage >= 1 && randomPercentage <= 30)
            {
                Instantiate(catPost[0]);
            }
            else if (randomPercentage >= 31 && randomPercentage <= 80)
            {
                Instantiate(catPost[1]);
            }
            else if (randomPercentage >= 81 && randomPercentage <= 100)
            {
                Instantiate(catPost[2]);
            }
        }

        //Post phase to spawn legendary cat post
        else if (thisStage.currentStage == StageValues.stage4)
        {
            Instantiate(catPost[3]);
            thisStage.currentStage = StageValues.stage5;
        }
    }
}
