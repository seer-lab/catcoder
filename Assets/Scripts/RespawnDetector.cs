using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnDetector : MonoBehaviour
{
    public Transform respawnSpot;
    private bool currentlyOccupied;

    public List<GameObject> prefabList = new List<GameObject>(); //Select from a list of prefabs

    //TO-TRY --> Make 4 list of words to assign to 4 arrays
    private static string[] boolArray = { "True", "False"};
    private static string[] stringArray = { "Sweetness", "Catnip", "Bucket", "Luigi", "Zelda" };
    private static string[] floatArray = { "3.1415", "0.01", "0.99" };
    private static string[] intArray = { "32", "11", "0", "255", "25" };


    private string[][] selectionArray = new string[4][] { boolArray, stringArray, floatArray, intArray };

    [SerializeField] BoolAssetValue[] stageValues;
    [SerializeField] BoolAssetValue[] stageCompleted;

    [SerializeField] BoolAssetValue[] spawnSpecial;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Placing bucket on start");
        //Spawn();
        Debug.Log("transform names: " + transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stageValues[1].value);
        if (stageValues[1].value == true && stageCompleted[0].value == true)
        {
            if (spawnSpecial[0].value == true)
            {
                if (!currentlyOccupied)
                {
                    //Set time respawn to 5 seconds
                    SpawnSpecific("phase1");
                }
                
                //spawnSpecial[0].value = false;
                //stageValues[1].value = false;
            }
        }

        if (stageValues[4].value == true && stageCompleted[1].value == true)
        {
            if (spawnSpecial[1].value == true)
            {
                if (!currentlyOccupied)
                {
                    Debug.Log("phase 2 start");
                    //Set time respawn to 5 seconds
                    Spawn();
                }
            }
        }

        else if (stageValues[5].value == true && stageCompleted[4].value == true)
        {
            if(spawnSpecial[2].value == true)
            {
                if (!currentlyOccupied)
                {
                    Debug.Log("repsawning?");
                    //Set time respawn to 5 seconds
                    Spawn();
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("stage0 is : " + stageValues[0].value);
        Debug.Log("stage1 is : " + stageValues[1].value);
        Debug.Log("stage2 is : " + stageValues[2].value);
        Debug.Log("stage3 is : " + stageValues[3].value);
        Debug.Log("stage4 is : " + stageValues[4].value);
        Debug.Log("stage5 is : " + stageValues[5].value);
        Debug.Log("stage6 is : " + stageValues[6].value);
        Debug.Log("stage7 is : " + stageValues[7].value);
        Debug.Log("stage8 is : " + stageValues[8].value);

        if (stageValues[1].value == true && stageCompleted[0].value == true)
        {
            if (other.gameObject.tag == "Bowl" && !other.isTrigger)
            {
                currentlyOccupied = false;
            }
        }
        if (stageValues[4].value == true && stageCompleted[1].value == true)
        {
            if (other.gameObject.tag == "Bowl" && !other.isTrigger)
            {
                currentlyOccupied = false;
            }
        }
        if (stageValues[5].value == true && stageCompleted[4].value == true)
        {
            Debug.Log("stage5 is : " + stageValues[5].value);
            Debug.Log("comp4 is : " + stageCompleted[4].value);
            Debug.Log("hello?");
            if (other.gameObject.tag == "Bowl" && !other.isTrigger)
            {
                currentlyOccupied = false;
                //Check to see if spot is currently occupied
                //This may be redundant
                if (!currentlyOccupied)
                {
                    //Set time respawn to 5 seconds
                    StartCoroutine(Respawn(other, 5));
                }
            }
        } 
    }

    IEnumerator Respawn(Collider2D other, int time)
    {   
        yield return new WaitForSeconds(time);
        Spawn();
        Debug.Log("Respawning!");
    }

    public void Spawn()
    {
        int prefabIndex = Random.Range(0, prefabList.Count); //min inclusive, max exclusive
        GameObject bucket = Instantiate(prefabList[prefabIndex]);
        bucket.transform.position = respawnSpot.position;
        bucket.transform.parent = transform;

        int first = prefabIndex;
        int second = Random.Range(0, selectionArray[prefabIndex].Length);
        Debug.Log("first: " + first + ", second: " + second);
        bucket.GetComponentInChildren<TextMeshPro>().text = selectionArray[first][second];
        currentlyOccupied = true;
    }
    public void SpawnSpecific(string phase)
    {
        if (phase == "phase1")
        {
                GameObject bucket = Instantiate(prefabList[1]);
                bucket.transform.position = respawnSpot.position;
                bucket.transform.parent = transform;

                bucket.GetComponentInChildren<TextMeshPro>().text = "Scruffy";
                currentlyOccupied = true;
        }
        if (phase == "phase2")
        {
            Spawn();
        }
    }
}
