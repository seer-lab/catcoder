using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

public class InfoPanelController : MonoBehaviour
{
    [SerializeField] private GameObject infoCanvas;

    private int currentScore;

    [SerializeField] private GameObject popupPanel;
    [SerializeField] private GameObject progressPanel;
    [SerializeField] private Image mask;

    [SerializeField] BoolAssetValue isSpeaking;
    private bool isPlaying;

    [SerializeField] TileBase tile;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Vector3Int cell;

    [SerializeField] StageClassAssetValue stage;
    [SerializeField] DialogueStateAssetValue thisStage;

    [SerializeField] GameObject dialogueText1;
    [SerializeField] GameObject dialogueText2;

    private void Start()
    {
        isPlaying = false;
        /*
        Debug.Log("starting");
        isPlaying = false;

        //Stage 1
        stage.stage1noHQ = Random.Range(5, 10);
        stage.stage1noMQ = 0;
        stage.stage1forLen = 0;

        //Stage 2
        stage.stage2noHQ = Random.Range(5, 10);
        stage.stage2noMQ = Random.Range(5, 10);
        stage.stage2forLen = Random.Range(40, 50);

        Debug.Log("Start done");
        */

    }
    void Update()
    {
        
        if (!isPlaying)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            infoCanvas.SetActive(false);
        }
    }
    public void EnableCanvas()
    {
        isPlaying = true;
        infoCanvas.SetActive(true);
        Debug.Log("stage is supposed to be :" + stage.stage1noHQ);
        Debug.Log("Enabled canvas");
        SetInfo();
    }

    public void SetInfo()
    {
        Debug.Log("Setting info");
        string stringToSet;
        string typeToSet;
        
        if (thisStage.currentStage == StageValues.stage1 || thisStage.currentStage == StageValues.stage1a)
        {
            stringToSet = "Current Inoperable";
            typeToSet = "Current Inoperable";
            dialogueText1.GetComponent<TextMeshProUGUI>().text = stringToSet;
            dialogueText2.GetComponent<TextMeshProUGUI>().text = typeToSet;
        }
        else if (thisStage.currentStage == StageValues.stage2)
        {
            stringToSet = "Amount of High Quality posts required: " + stage.stage1noHQ + "!\nPlease deposit in the space provided.";
            typeToSet = "Cat posts will appear continuously!";
            dialogueText1.GetComponent<TextMeshProUGUI>().text = stringToSet;
            dialogueText2.GetComponent<TextMeshProUGUI>().text = typeToSet;
        }
        else if (thisStage.currentStage == StageValues.stage3)
        {
            stringToSet = "Amount of High Quality posts required: " + stage.stage2noHQ + "!\nAmount of Master Quality posts required: " + stage.stage2noMQ + "!\nPlease deposit in the space provided.";
            typeToSet = "There are " + stage.stage2forLen + "cat posts coming down the production line, sort them!";
            dialogueText1.GetComponent<TextMeshProUGUI>().text = stringToSet;
            dialogueText2.GetComponent<TextMeshProUGUI>().text = typeToSet;
        }  
    }
}
