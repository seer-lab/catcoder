using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSign2 : Interactable
{
    [SerializeField] private TextAssetValue dialogueValue; //intermediate dialogue value
    [SerializeField] private TextAsset myDialogue; // sign dialogue
    [SerializeField] private Notification branchingDialogueNotification;

    [SerializeField] private ItemDetector myFromObject; //ADDED
    [SerializeField] private ItemDetectorValue fromObject; //ADDED

    [SerializeField] private GameObject popupPanel;
    [SerializeField] private GameObject[] catPost;

    private float nextActionTime = 4f;
    private float period = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] posts = GameObject.FindGameObjectsWithTag("CatPostMoving");

        if(posts.Length < 5)
        {
            if(Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;
                SpawnRandomByPercentage();
            }
        }


        if (playerInRange)
        {
            if (Input.GetKey(KeyCode.R))
            {
                fromObject.value = myFromObject;



                if (fromObject.value.itemPlaced)
                {
                    dialogueValue.value = myDialogue;
                    branchingDialogueNotification.Raise();
                }
                else
                {
                    popupPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Please place down a bowl first!";

                    PopupPanelController.OpenPopup(popupPanel);
                    popupPanel.SetActive(true);
                    StartCoroutine(PopupPanelController.PopupAndDelay(5, popupPanel));

                }
            }
        }
    }

    private void SpawnRandomByPercentage()
    {
        int randomPercentage = Random.Range(1, 100);

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
