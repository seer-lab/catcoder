using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnDetectorLevel3 : MonoBehaviour
{
    public bool currentlyOccupied;

    public List<GameObject> prefabList = new List<GameObject>(); //Select from a list of prefabs

    private void Start()
    {
        Spawn();
    }
    // Update is called once per frame
    void Update()
    {
        if (!currentlyOccupied)
        {
            StartCoroutine(Respawn(2));
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Catnip")
        {
            Debug.Log("catnip");
            currentlyOccupied = false;
        }  
    }

    IEnumerator Respawn(int time)
    {
        yield return new WaitForSeconds(time);
        if (!currentlyOccupied)
        {
            Spawn();
            Debug.Log("Respawning!");
        }
    }

    public void Spawn()
    {
        int prefabIndex = Random.Range(0, prefabList.Count); //min inclusive, max exclusive
        GameObject bucket = Instantiate(prefabList[prefabIndex]);
        bucket.transform.position = transform.position;
        bucket.transform.parent = transform;

        currentlyOccupied = true;
    }
}
