using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPanelController : MonoBehaviour
{
    //[SerializeField] public GameObject popupPanel;
    public static void OpenPopup(GameObject popupPanel)
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

    public static void ClosePopup(GameObject popupPanel)
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

    public static IEnumerator PopupAndDelay(int time, GameObject popupPanel)
    {
        Debug.Log("Waiting...");

        yield return new WaitForSeconds(time);
        Debug.Log("Times up");
        ClosePopup(popupPanel);
        yield return new WaitForSeconds((float)0.85);
        popupPanel.SetActive(false);

    }
}
