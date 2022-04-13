using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EndgameUiManager : MonoBehaviour
{
    [SerializeField] private GameObject endgameScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            endgameScreen.SetActive(true);
        }
    }

    public void ExitGame()
    {
        EditorApplication.ExecuteMenuItem("Edit/Play");
    }
}
