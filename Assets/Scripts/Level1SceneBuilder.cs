using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SceneBuilder : MonoBehaviour
{
    [SerializeField] private CurrentLevelValue currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel.currentLevel = LevelValues.level1_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
