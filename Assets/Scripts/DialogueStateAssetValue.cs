using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageValues
{
    stage0,  //Nothing yet to happen
    stage1,  //Introduction and dialogue before hitting the emergency stop
    stage1a, //Intermediary
    stage2,  //After emergency stop is hit, and before phase 2 begins
    stage2a, //Intermediary
    stage3,  //After success of phase 2, and before phase 3 beings
    stage3a, //Intermediary
    stage4,  //After success of the final phase
    stage5,  //After picking up legendary cat post
}

[CreateAssetMenu(menuName = "Scriptable Objects/New DialogueState Value", fileName = "New DialogueState Asset")]
public class DialogueStateAssetValue : ScriptableObject
{
    public StageValues currentStage;
}