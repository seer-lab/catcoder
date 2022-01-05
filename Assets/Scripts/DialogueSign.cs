using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSign : Interactable
{
    [SerializeField] private TextAssetValue dialogueValue; //intermediate dialogue value
    [SerializeField] private TextAsset myDialogue; // sign dialogue
    [SerializeField] private Notification branchingDialogueNotification;

    [SerializeField] private ItemDetector myBowlType; //ADDED
    [SerializeField] private ObjectValue bowlType; //ADDED

    [SerializeField] private ItemDetector myFromObject; //ADDED
    [SerializeField] private ItemDetectorValue fromObject; //ADDED

    [SerializeField] private GameObject popupPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKey(KeyCode.R))
            {

                Debug.Log("from object val: " + fromObject.value);
                Debug.Log("my from object: " + myFromObject);
                bowlType.value = myBowlType.itemPlaced; //ADDED
                fromObject.value = myFromObject;
                Debug.Log("from object after redef: " + fromObject.value);
                Debug.Log("This1: " + fromObject.value.itemPlaced);
                Debug.Log("This2: " + bowlType.value);
                Debug.Log("This3: " + myBowlType.itemPlaced);

                if (fromObject.value.itemPlaced)
                {
                    dialogueValue.value = myDialogue;
                    branchingDialogueNotification.Raise();
                }
                else
                {
                    popupPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Please place down a bowl first!";
                    //OpenPopup();
                    //popupPanel.SetActive(true);
                    //StartCoroutine(PopupAndDelay(5));

                    PopupPanelController.OpenPopup(popupPanel);
                    popupPanel.SetActive(true);
                    StartCoroutine(PopupPanelController.PopupAndDelay(5, popupPanel));

                }
            }
        }
    }
/*
    public void OpenPopup()
    {
        if (popupPanel)
        {
            Animator animator = popupPanel.GetComponent<Animator>();
            if (animator)
            {
                animator.Play("Base Layer.SlideDown");
            }
        }
    }

    public void ClosePopup()
    {
        if (popupPanel)
        {
            Animator animator = popupPanel.GetComponent<Animator>();
            if (animator)
            {
                animator.Play("Base Layer.SlideUp");
            }
        }
    }

    IEnumerator PopupAndDelay(int time)
    {
        Debug.Log("Waiting...");
        
        yield return new WaitForSeconds(time);
        Debug.Log("Times up");
        ClosePopup();
        yield return new WaitForSeconds((float)0.85);
        popupPanel.SetActive(false);

    }*/
}
