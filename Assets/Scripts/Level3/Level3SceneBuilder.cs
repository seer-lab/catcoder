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
    [SerializeField] private GameObject[] orbitObjects; //set gotten from the scene

    [SerializeField] private PlayerMovement player;

    private float nextActionTime = 4f;
    private float period = 1.04f;

    private Spawning currentlySpawning;
    private int spawningCounter;
    private int activatingCounter;

    //[SerializeField] private TdArrayAssetValue orbitObjectsArray;      //Set of all active or not

    [SerializeField] private ArrayAssetValue orbitObjectsInner;
    [SerializeField] private ArrayAssetValue orbitObjectsMid;
    [SerializeField] private ArrayAssetValue orbitObjectsOuter;
    [SerializeField] private ArrayAssetValue orbitObjectsFar;

    private List<GameObject> farObjectList;
    private List<GameObject> outerObjectList;
    private List<GameObject> midObjectList;
    private List<GameObject> innerObjectList;

    [SerializeField] private OrbitObjectsActiveAssetValue activeOrbit;

    private bool wasRemoved = false;

    [SerializeField] private CurrentLevelValue currentLevel;

    private void Start()
    {
        currentLevel.currentLevel = LevelValues.level1_3;

        currentlySpawning = Spawning.positive;

        spawningCounter = 0;
        activatingCounter = 0;

        player.speed = 8;
        //orbitObjectsArray.tdArrayValue = new GameObject[6, 4];

        orbitObjectsInner.arrayValue = new GameObject[6];
        orbitObjectsMid.arrayValue = new GameObject[6];
        orbitObjectsOuter.arrayValue = new GameObject[6];
        orbitObjectsFar.arrayValue = new GameObject[6];

        //Default far set to active
        activeOrbit.currentActiveOrbit = OrbitsActive.farActive;

        farObjectList = new List<GameObject>();
        outerObjectList = new List<GameObject>();
        midObjectList = new List<GameObject>();
        innerObjectList = new List<GameObject>();
    }
    private void Update()
    {
        if (spawningCounter == 6)
        {
            currentlySpawning = Spawning.negative;
            CheckActives();
        }

        if (currentlySpawning == Spawning.positive)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + period;
                /*
                orbitObjectsArray.tdArrayValue[spawningCounter, 0] = Instantiate(orbitObjects[0], bossObject.transform.position, Quaternion.identity);
                orbitObjectsArray.tdArrayValue[spawningCounter, 1] = Instantiate(orbitObjects[1], bossObject.transform.position, Quaternion.identity);
                orbitObjectsArray.tdArrayValue[spawningCounter, 2] = Instantiate(orbitObjects[2], bossObject.transform.position, Quaternion.identity);
                orbitObjectsArray.tdArrayValue[spawningCounter, 3] = Instantiate(orbitObjects[3], bossObject.transform.position, Quaternion.identity);
                */

                orbitObjectsInner.arrayValue[spawningCounter] = Instantiate(orbitObjects[0], bossObject.transform.position, Quaternion.identity);
                orbitObjectsMid.arrayValue[spawningCounter] =   Instantiate(orbitObjects[1], bossObject.transform.position, Quaternion.identity);
                orbitObjectsOuter.arrayValue[spawningCounter] = Instantiate(orbitObjects[2], bossObject.transform.position, Quaternion.identity);
                orbitObjectsFar.arrayValue[spawningCounter] =   Instantiate(orbitObjects[3], bossObject.transform.position, Quaternion.identity);

                innerObjectList.Add(orbitObjectsInner.arrayValue[spawningCounter]);
                midObjectList.Add(orbitObjectsMid.arrayValue[spawningCounter]);
                outerObjectList.Add(orbitObjectsOuter.arrayValue[spawningCounter]);
                farObjectList.Add(orbitObjectsFar.arrayValue[spawningCounter]);
                spawningCounter += 1;

            }
        }    
    }

    public void CheckActives()
    {
        var checkActives = false;
        

        //Far Layer
        if (activeOrbit.currentActiveOrbit == OrbitsActive.farActive)
        {
            foreach(var activeObjects in farObjectList)
            {
                if (activeObjects.gameObject.transform.localScale == new Vector3(1, 1, 1))
                {
                    checkActives = true;
                }
                else
                {
                    if (farObjectList.Count == 0)
                    {
                        activeOrbit.currentActiveOrbit = OrbitsActive.outerActive;
                    }
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
            var counter = outerObjectList.Count;
            
            foreach (var activeObjects in outerObjectList)
            {
                
                counter--;
                //Debug.Log(counter);
                if (activeObjects.gameObject.transform.localScale == new Vector3(1.2f, 1.2f, 1.2f))
                {
                    checkActives = true;
                }
                else
                {
                    outerObjectList.Remove(activeObjects);
                    Debug.Log("removed one");
                    wasRemoved = true;
                    Debug.Log("was removed?: " + wasRemoved);
                }
                Debug.Log("was removed?: " + wasRemoved + " counter: " + counter);
                if (wasRemoved == true && counter == 0)
                {
                    //Remove recently de-activated object from the list
                    wasRemoved = false;

                    //If outerobjectslist is empty set active layer to mid
                    if (outerObjectList.Count == 0)
                    {
                        activeOrbit.currentActiveOrbit = OrbitsActive.midActive;
                    }
                    //else set back to far and regen previous layer
                    else
                    {
                        Debug.Log("At least one in layer 2 has been deactivated");

                        activeOrbit.currentActiveOrbit = OrbitsActive.farActive;

                        foreach (var previousObjects in farObjectList)
                        {
                            //Reactivate the entire previous layer
                            previousObjects.gameObject.transform.localScale = new Vector3(1, 1, 1);
                        }
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
            var counter = midObjectList.Count;

            foreach (var activeObjects in midObjectList)
            {
                counter--;

                if (activeObjects.gameObject.transform.localScale == new Vector3(1.2f, 1.2f, 1.2f))
                {
                    checkActives = true;
                }
                else
                {
                    //Remove recently de-activated object from the list
                    midObjectList.Remove(activeObjects);
                    wasRemoved = true;
                    
                }
                if (wasRemoved == true && counter == 0)
                {
                    wasRemoved = false;

                    if (midObjectList.Count == 0)
                    {
                        activeOrbit.currentActiveOrbit = OrbitsActive.innerActive;
                    }
                    else
                    {
                        Debug.Log("At least one in layer 3 has been deactivated");

                        activeOrbit.currentActiveOrbit = OrbitsActive.outerActive;


                        outerObjectList = new List<GameObject>(orbitObjectsOuter.arrayValue);

                        foreach (var previousObjects in outerObjectList)
                        {
                            //Reactivate the entire previous layer
                            previousObjects.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                        }
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
            //Debug.Log("Layer 4");

            var counter = innerObjectList.Count;

            foreach(var activeObjects in innerObjectList)
            {
                counter--;

                if (activeObjects.gameObject.transform.localScale == new Vector3(1.1f, 1.1f, 1.1f))
                {
                    checkActives = true;
                }
                else
                {
                    //Remove recently de-activated object from the list
                    innerObjectList.Remove(activeObjects);
                    wasRemoved = true;

                    
                }
                if (wasRemoved == true && counter == 0)
                {
                    wasRemoved = false;

                    if (innerObjectList.Count == 0)
                    {
                        Debug.Log("Winner!");
                    }
                    else
                    {
                        Debug.Log("At least one in layer 4 has been deactivated");

                        activeOrbit.currentActiveOrbit = OrbitsActive.midActive;

                        midObjectList = new List<GameObject>(orbitObjectsMid.arrayValue);


                        foreach (var previousObjects in midObjectList)
                        {
                            previousObjects.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                        }
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
