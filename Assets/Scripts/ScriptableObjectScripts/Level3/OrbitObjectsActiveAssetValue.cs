using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbitsActive
{
    farActive,
    outerActive,
    midActive,
    innerActive
}

[CreateAssetMenu(menuName = "Scriptable Objects/New OrbitActive Value", fileName = "New OrbitActive Asset")]
public class OrbitObjectsActiveAssetValue : ScriptableObject
{
    public OrbitsActive currentActiveOrbit;
}
