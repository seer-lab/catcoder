using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level0SceneBuilder : MonoBehaviour
{

    [SerializeField] private CurrentLevelValue currentLevel;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject background;

    [SerializeField] private GameObject header;

    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject aboutButton;
    [SerializeField] private GameObject creditsButton;

    [SerializeField] private GameObject aboutPanel;
    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private GameObject backButton;

    [SerializeField] private CompletionCheck isCompleted;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel.currentLevel = LevelValues.level1_0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCompleted.level0Completion == true)
        {
            canvas.SetActive(false);
        }
    }

    public void StartButton()
    {
        //Start the game
        //Disable all menu elements
        canvas.SetActive(false);

        isCompleted.level0Completion = true;
    }

    public void AboutButton()
    {
        //Disable buttons, enable info panel, set header
        startButton.SetActive(false);
        aboutButton.SetActive(false);
        creditsButton.SetActive(false);

        aboutPanel.SetActive(true);
        backButton.SetActive(true);

        header.GetComponentInChildren<TextMeshProUGUI>().text = "About";
    }

    public void CreditsButton()
    {
        //Disable buttons, enable info panel, set header
        startButton.SetActive(false);
        aboutButton.SetActive(false);
        creditsButton.SetActive(false);

        creditsPanel.SetActive(true);
        backButton.SetActive(true);

        header.GetComponentInChildren<TextMeshProUGUI>().text = "Credits";
    }

    public void BackButton()
    {
        //Disable both info panels, reset header, set original buttons
        aboutPanel.SetActive(false);
        creditsPanel.SetActive(false);

        backButton.SetActive(false);
        header.GetComponentInChildren<TextMeshProUGUI>().text = "Cat Coders";

        startButton.SetActive(true);
        aboutButton.SetActive(true);
        creditsButton.SetActive(true);
    }
}
