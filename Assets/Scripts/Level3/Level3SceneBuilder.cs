using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spawning
{
    positive,
    negative
}
public class Level3SceneBuilder : MonoBehaviour
{
    [SerializeField] private GameObject bossObject;
    [SerializeField] private GameObject[] orbitObjects;

    private float nextActionTime = 4f;
    private float period = 1.04f;

    private Spawning currentlySpawning;
    private int counter;

    private void Start()
    {
        currentlySpawning = Spawning.positive;
        counter = 0;
    }
    private void Update()
    {
        if (counter == 6)
        {
            currentlySpawning = Spawning.negative;
        }

        if (currentlySpawning == Spawning.positive)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;
                Instantiate(orbitObjects[0], bossObject.transform.position, Quaternion.identity);
                Instantiate(orbitObjects[1], bossObject.transform.position, Quaternion.identity);
                Instantiate(orbitObjects[2], bossObject.transform.position, Quaternion.identity);
                Instantiate(orbitObjects[3], bossObject.transform.position, Quaternion.identity);
                counter += 1;
            }
        }
    }
}
