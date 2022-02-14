using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class StageRequirements
{
    public int noHQ;
    public int noMQ;
    public int forLen;
}
*/
[CreateAssetMenu(menuName = "Scriptable Objects/New StageClass Value", fileName = "New StageClass Asset")]
public class StageClassAssetValue : ScriptableObject
{
    //public StageRequirements stage1Reqs;
    //public StageRequirements stage2Reqs;

    public int stage1noHQ;
    public int stage1noMQ;
    public int stage1forLen;

    public int stage2noHQ;
    public int stage2noMQ;
    public int stage2forLen;
}
