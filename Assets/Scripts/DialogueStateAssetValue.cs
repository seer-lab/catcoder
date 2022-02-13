using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageValues
{
    stage1, //Introduction and dialogue before hitting the emergency stop
    stage2, //After emergency stop is hit, and before phase 2 begins
    stage3, //After success of phase 2, and before phase 3 beings
    stage4, //After success of the final phase
}

[CreateAssetMenu(menuName = "Scriptable Objects/New DialogueState Value", fileName = "New DialogueState Asset")]
public class DialogueStateAssetValue : ScriptableObject
{
    public StageValues currentStage;
}