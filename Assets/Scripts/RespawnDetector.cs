using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnDetector : MonoBehaviour
{
    public GameObject bucketPrefab;
    public Transform respawnSpot;
    private bool currentlyOccupied;

    public List<GameObject> prefabList = new List<GameObject>(); //Select from a list of prefabs

    //TO-TRY --> Make 4 list of words to assign to 4 arrays
    private static string[] boolArray = { "True", "False"};
    private static string[] stringArray = { "Scruffy", "Catnip", "Bucket", "Luigi", "Zelda" };
    private static string[] floatArray = { "3.1415", "0.01", "0.99" };
    private static string[] intArray = { "32", "11", "0", "255", "25" };


    private string[][] selectionArray = new string[4][] { boolArray, stringArray, floatArray, intArray };

    //public GameObject objectToLabel; //DELETE?


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Placing bucket on start");
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bowl" && !other.isTrigger)
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

}
