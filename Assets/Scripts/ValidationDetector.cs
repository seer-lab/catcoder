using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationDetector : MonoBehaviour
{
    public Transform placeSpot;
    public GameObject itemPlaced;
    public GameObject[] newPrefab;

    //Detect when an object enters the collider
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CatPostHeld" && !other.isTrigger)
        {
            itemPlaced = other.gameObject;
            other.transform.position = placeSpot.position;
            other.transform.parent = transform;
            other.gameObject.layer = 7;
            //other.GetComponent
        }
    }

    public void changeObject(GameObject bowl, int choice, bool correct)
    {

    }
}
