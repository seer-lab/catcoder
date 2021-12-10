using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Transform placeSpot;
    public GameObject itemPlaced;
    public bool currentlyOccupied;
    public Sprite newSprite;
    private string newTag = "TransformedObject";
    //private int wasClicked = 4;

    //public BranchingDialogueController getIndexClicked;

    private void Start()
    {
        //getIndexClicked = buttonPressed.GetComponent<BranchingDialogueController>();
        //Debug.Log(getIndexClicked.clickedIndex);
        
    }

    private void Update()
    {
        //wasClicked = getIndexClicked.clickedIndex;


    }
    //Detect when an object enters the collider
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Set what the itemplaced is
        itemPlaced = other.gameObject;
        //When an object of tag Object enters, this happens
        ////Generally Dynamic buckets trigger when places, and static trigger when removed..

        //If the object is detected to be placed
        if (other.gameObject.tag == "Object" && !other.isTrigger)
        {
            
            Debug.Log("Object entered");
            //Transform the position of the placed object to the spot and set as child
            if (!currentlyOccupied)
            {
                Debug.Log("now occupied");
                other.transform.position = placeSpot.position;
                other.transform.parent = transform;
                currentlyOccupied = true;

                //Do event once placed
                //changeObject(other.gameObject);

                Debug.Log(other.gameObject.tag);
                other.gameObject.tag = newTag;
                Debug.Log(other.gameObject.tag);
            }
            else
            {
                Debug.Log("occupied");
                //Stop it from being placed
            }  

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        itemPlaced = null; //Unset it

        if (other.gameObject.tag == "Object" && !other.isTrigger)
        {
            
            Debug.Log("Object exited");
            currentlyOccupied = false;
            Debug.Log("now not occupied");

        }

    }


    //TODO: (Not specifically in this script per ce)
    //      [DONE]-once trigger is called, set object as child to item detector
    //      -set a boolean status as detect is full/currently detecting
    //      [DONE:Set to kinematic]-make object static (may not work?)
    //      [DONE:Set new method to be called]-activate -something- that changes the object
    //      [DONE:Sorta does this anyways]-if this works, find a way to change object based on object type
    //      -create respawnable item detector (if item doesnt exist, place new)
    //      -create item detector that destroys object
    //      -if this works, destroy based on the object type
    //      [DONE]-change object type after event is fired to switch model

    // Update is called once per frame

    public void changeObject(GameObject bucket)
    {
        
        Debug.Log(bucket.GetComponent<SpriteRenderer>().sprite);
        bucket.GetComponent<SpriteRenderer>().sprite = newSprite;
        Debug.Log("OKAY YOU GOT HERE");
        Debug.Log("bucket is: " + bucket.name);
        Debug.Log(bucket.GetComponent<SpriteRenderer>().sprite);
    }


}
