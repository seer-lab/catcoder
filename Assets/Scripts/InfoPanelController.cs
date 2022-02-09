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

    [SerializeField] StageClassAssetValue stage1;
    [SerializeField] StageClassAssetValue stage2;
    [SerializeField] BoolAssetValue isFirstStage;

    [SerializeField] GameObject dialogueText1;
    [SerializeField] GameObject dialogueText2;

    private void Start()
    {
        isPlaying = false;

        //Stage 1
        stage1.noHQ = Random.Range(5, 10);
        stage1.noMQ = 0;
        stage1.forLen = 0;

        //Stage 2
        stage2.noHQ = Random.Range(5, 10);
        stage2.noMQ = Random.Range(5, 10);
        stage2.forLen = Random.Range(40, 50);

        Debug.Log("Start done");
        
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
        Debug.Log("Enabled canvas");
        SetInfo();
    }

    public void SetInfo()
    {
        Debug.Log("Setting info");
        string stringToSet;
        string typeToSet;
        
        //Debug.Log("current stage: " + isFirstStage.value);
        Debug.Log("here?");
        if (isFirstStage.value == true)
        {
            stringToSet = "Amount of High Quality posts required: " + stage1.noHQ + "!\nPlease deposit in the space provided.";
            typeToSet = "Cat posts will appear continuously!";
            dialogueText1.GetComponent<TextMeshProUGUI>().text = stringToSet;
            dialogueText2.GetComponent<TextMeshProUGUI>().text = typeToSet;
        }
        else if (isFirstStage.value == false)
        {
            stringToSet = "Amount of High Quality posts required: " + stage2.noHQ + "!\nAmount of Master Quality posts required: " + stage2.noMQ + "!\nPlease deposit in the space provided.";
            typeToSet = "There are " + stage2.forLen + "cat posts coming down the production line, sort them!";
            dialogueText1.GetComponent<TextMeshProUGUI>().text = stringToSet;
            dialogueText2.GetComponent<TextMeshProUGUI>().text = typeToSet;
        }  
    }
}
