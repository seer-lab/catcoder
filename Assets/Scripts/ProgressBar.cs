using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    //public int minimum;
    //public int maximum;
    //public int current;
    //public Image mask;
    //public GameObject progressPanel;


    // Start is called before the first frame update
/*    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }*/

    public static void GetCurrentFill(Image mask, GameObject progressPanel, int minimum, int maximum, int current)
    {
        float currentOffset = current - minimum; //2 - 0 for correct  //
        float maximumOffset = maximum - minimum; //20 - 0 for correct //
        float fillAmount = currentOffset / maximumOffset; // 2 / 20 --> 10% per correct
        mask.fillAmount = fillAmount;

        progressPanel.GetComponentInChildren<TextMeshProUGUI>().text = currentOffset + "/" + maximum;
    }
}
