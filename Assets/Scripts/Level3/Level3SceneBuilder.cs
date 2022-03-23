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

    [SerializeField] private PlayerMovement player;

    private float nextActionTime = 4f;
    private float period = 1.04f;

    private Spawning currentlySpawning;
    private int spawningCounter;
    private int activatingCounter;

    [SerializeField] private TdArrayAssetValue orbitObjectsArray;
    [SerializeField] private OrbitObjectsActiveAssetValue activeOrbit;

    private void Start()
    {
        currentlySpawning = Spawning.positive;

        spawningCounter = 0;
        activatingCounter = 0;

        player.speed = 8;
        orbitObjectsArray.tdArrayValue = new GameObject[6, 4];

        //Default far set to active
        activeOrbit.currentActiveOrbit = OrbitsActive.farActive;
    }
    private void Update()
    {
        if (spawningCounter == 6)
        {
            currentlySpawning = Spawning.negative;
        }

        if (currentlySpawning == Spawning.positive)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;
                orbitObjectsArray.tdArrayValue[spawningCounter, 0] = Instantiate(orbitObjects[0], bossObject.transform.position, Quaternion.identity);
                orbitObjectsArray.tdArrayValue[spawningCounter, 1] = Instantiate(orbitObjects[1], bossObject.transform.position, Quaternion.identity);
                orbitObjectsArray.tdArrayValue[spawningCounter, 2] = Instantiate(orbitObjects[2], bossObject.transform.position, Quaternion.identity);
                orbitObjectsArray.tdArrayValue[spawningCounter, 3] = Instantiate(orbitObjects[3], bossObject.transform.position, Quaternion.identity);
                spawningCounter += 1;
            }
        }

        CheckActives();
    }

    public void CheckActives()
    {
        var arraylen = orbitObjectsArray.tdArrayValue.GetLength(0);
        var checkActives = false;

        //Far Layer
        if (activeOrbit.currentActiveOrbit == OrbitsActive.farActive)
        {
            for (int i = 0; i < arraylen; i++)
            {
                //If one exsists in the array, flag active as true
                if (orbitObjectsArray.tdArrayValue[i, 3].gameObject.transform.localScale == new Vector3(1, 1, 1))
                {
                    checkActives = true;
                }
            }

            if (!checkActives)
            {
                activeOrbit.currentActiveOrbit = OrbitsActive.outerActive;
            }
        }

        //Outer Layer
        if (activeOrbit.currentActiveOrbit == OrbitsActive.outerActive)
        {
            Debug.Log("Layer 2");
            for (int i = 0; i < arraylen; i++)
            {
                //If one exsists in the array, flag active as true
                if (orbitObjectsArray.tdArrayValue[i, 2].gameObject.transform.localScale == new Vector3(1.2f, 1.2f, 1.2f))
                {
                    checkActives = true;
                }
                else
                {
                    Debug.Log("At least one in layer 2 has been deactivated");
                    //Reactivate layer 1
                    activeOrbit.currentActiveOrbit = OrbitsActive.farActive;

                    //Set previous layer back to true
                    for (int j = 0; j < arraylen; j++)
                    {
                        orbitObjectsArray.tdArrayValue[j, 3].gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }

                }
            }

            if (!checkActives)
            {
                activeOrbit.currentActiveOrbit = OrbitsActive.midActive;
            }
        }

        if (activeOrbit.currentActiveOrbit == OrbitsActive.midActive)
        {
            Debug.Log("Layer 3");
            for (int i = 0; i < arraylen; i++)
            {
                //If one exsists in the array, flag active as true
                if (orbitObjectsArray.tdArrayValue[i, 1].gameObject.transform.localScale == new Vector3(1.2f, 1.2f, 1.2f))
                {
                    checkActives = true;
                }
                else
                {
                    Debug.Log("At least one in layer 3 has been deactivated");
                    //Reactivate layer 1
                    activeOrbit.currentActiveOrbit = OrbitsActive.outerActive;

                    //Set previous layer back to true
                    for (int j = 0; j < arraylen; j++)
                    {
                        orbitObjectsArray.tdArrayValue[j, 2].gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                    }

                }
            }

            if (!checkActives)
            {
                activeOrbit.currentActiveOrbit = OrbitsActive.innerActive;
            }
        }

        if (activeOrbit.currentActiveOrbit == OrbitsActive.innerActive)
        {
            Debug.Log("Layer 4");
            for (int i = 0; i < arraylen; i++)
            {
                //If one exsists in the array, flag active as true
                if (orbitObjectsArray.tdArrayValue[i, 0].gameObject.transform.localScale == new Vector3(1.1f, 1.1f, 1.1f))
                {
                    checkActives = true;
                }
                else
                {
                    Debug.Log("At least one in layer 4 has been deactivated");
                    //Reactivate layer 1
                    activeOrbit.currentActiveOrbit = OrbitsActive.midActive;

                    //Set previous layer back to true
                    for (int j = 0; j < arraylen; j++)
                    {
                        orbitObjectsArray.tdArrayValue[j, 1].gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                    }

                }
            }

            if (!checkActives)
            {
                Debug.Log("Win condition");
            }
        }
    }
}
