using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/New 2DArray Value", fileName = "New 2DArray Asset")]
public class TdArrayAssetValue : ScriptableObject
{
    public GameObject[,] tdArrayValue;
}
