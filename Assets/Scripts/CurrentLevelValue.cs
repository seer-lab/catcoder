using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelValues
{
    level1_0,
    level1_1,
    level1_2,
    level1_3
}

[CreateAssetMenu(menuName = "Scriptable Objects/New CurrentLevel Value", fileName = "New CurrentLevel Asset")]
public class CurrentLevelValue : ScriptableObject
{
    public LevelValues currentLevel;
}
