using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSign2 : Interactable
{
    [SerializeField] private Notification infoDialogueNotification;

    [SerializeField] private GameObject popupPanel;
    [SerializeField] private GameObject[] catPost;

    private float nextActionTime = 4f;
    private float period = 4f;
    private int postNo = 5;


    [SerializeField] BoolAssetValue isStage1;

    // Start is called before the first frame update
    void Start()
    {
        isStage1.value = true;
    }

    // Update is called once per frame

    void Update()
    {
        GameObject[] posts = GameObject.FindGameObjectsWithTag("CatPostMoving");
       
        if (isStage1.value == true)
        {
            postNo = 5;
            period = 4f;
        }
        else if (isStage1.value == false)
        {
            postNo = 1;
            period = 2f;
        }
        
        

        if (posts.Length < postNo)
        {

            if (Time.time > nextActionTime)
            {
                Debug.Log("next action1: " + nextActionTime);
                nextActionTime = Time.time + period;
                Debug.Log("next action2: " + nextActionTime);
                SpawnRandomByPercentage();
            }
        }

        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                infoDialogueNotification.Raise();
            }
        }
    }

    private void SpawnRandomByPercentage()
    {
        int randomPercentage = Random.Range(1, 100);

        if(isStage1.value == true)
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
        else if(isStage1.value == false)
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

    }
}
