using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
  
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    //UI
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    [SerializeField] private CompletionCheck isCompleted;
    [SerializeField] private GameObject popupPanel;

    public void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }

        if (needText)
        {
            StartCoroutine(placeNameCo());
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if (sceneToLoad != "Room3Scene")
            {
                playerStorage.initialValue = playerPosition;
                //SceneManager.LoadScene(sceneToLoad);
                StartCoroutine(FadeCo());
                Debug.Log("triggered scene");
            }

            if (sceneToLoad == "Room3Scene" && isCompleted.level1Completion == true && isCompleted.level2Completion == true)
            {
                playerStorage.initialValue = playerPosition;
                //SceneManager.LoadScene(sceneToLoad);
                StartCoroutine(FadeCo());
                Debug.Log("triggered scene");
            }
            else
            {
                Debug.Log("Incomplete!");

                popupPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Required levels not completed";

                PopupPanelController.OpenPopup(popupPanel);
                popupPanel.SetActive(true);
                StartCoroutine(PopupPanelController.PopupAndDelay(5, popupPanel));
            }
        }
    }

    public IEnumerator FadeCo()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
