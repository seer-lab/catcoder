using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnDetectorLevel3 : MonoBehaviour
{
    [SerializeField] public GameObject prefabObject; //Select from a list of prefabs

    private bool currentlyOccupied;

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
        if (other.gameObject.tag == "Catnip1" || other.gameObject.tag == "Catnip2" || other.gameObject.tag == "Catnip3" || other.gameObject.tag == "Catnip4")
        {
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
        GameObject catObject = Instantiate(prefabObject);
        catObject.transform.position = transform.position;
        catObject.transform.parent = transform;

        currentlyOccupied = true;
    }
}
