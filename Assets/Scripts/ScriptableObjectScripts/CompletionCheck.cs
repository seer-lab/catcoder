using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/New CompletionCheck Value", fileName = "New CompletionCheck Asset")]
public class CompletionCheck : ScriptableObject
{
    public bool level0Completion = false;
    public bool level1Completion = false;
    public bool level2Completion = false;
    public bool level3Completion = false;
}
