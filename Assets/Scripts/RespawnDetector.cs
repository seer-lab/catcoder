using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDetector : MonoBehaviour
{
    public GameObject bucketPrefab;
    public Transform respawnSpot;
    private bool currentlyOccupied;

    public List<GameObject> prefabList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Placing bucket on start");
        int prefabIndex = Random.Range(0, prefabList.Count - 1);
        GameObject bucket = Instantiate(prefabList[prefabIndex]);
        bucket.transform.position = respawnSpot.position;
        bucket.transform.parent = transform;
        currentlyOccupied = true;
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
        int prefabIndex = Random.Range(0, prefabList.Count);
        GameObject bucket = Instantiate(prefabList[prefabIndex]);
        bucket.transform.position = respawnSpot.position;
        bucket.transform.parent = transform; //Just added, see if its fine
        currentlyOccupied = true;
        Debug.Log("Respawning!");
    }

}
