using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Transform placeSpot;
    public GameObject itemPlaced;
    public bool currentlyOccupied;
    public Sprite newSprite;
    private string newTag = "PlacedBowl";
    public GameObject[] newPrefab;
    //private int wasClicked = 4;

    [SerializeField] GameObject[] pourAnimationObject;

    //public BranchingDialogueController getIndexClicked;

    private void Start()
    {
        //getIndexClicked = buttonPressed.GetComponent<BranchingDialogueController>();
        //Debug.Log(getIndexClicked.clickedIndex);
        currentlyOccupied = false;
        
    }

    private void Update()
    {
        //wasClicked = getIndexClicked.clickedIndex;


    }
    //Detect when an object enters the collider
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Set what the itemplaced is
        
        //When an object of tag Object enters, this happens
        ////Generally Dynamic buckets trigger when places, and static trigger when removed..

        //If the object is detected to be placed
        if (other.gameObject.tag == "Bowl" && !other.isTrigger)
        {
            //itemPlaced = other.gameObject;
            Debug.Log("Object entered");
            //Transform the position of the placed object to the spot and set as child
            if (!currentlyOccupied)
            {
                itemPlaced = other.gameObject;
                Debug.Log("now occupied");
                other.transform.position = placeSpot.position;
                other.transform.parent = transform;
                currentlyOccupied = true;

                //Do event once placed
                //changeObject(other.gameObject);

                Debug.Log(other.gameObject.tag);
                other.gameObject.tag = newTag;
                Debug.Log(other.gameObject.tag);
                other.gameObject.layer = 7;
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
        //itemPlaced = null; //Unset it

        if (other.gameObject.tag == "PlacedBowl" && !other.isTrigger)
        {
            if (currentlyOccupied)
            {
                itemPlaced = null; //Unset it if tag is
                Debug.Log("Object exited");
                currentlyOccupied = false;
                Debug.Log("now not occupied");
            }


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

    public void changeObject(GameObject bowl, int choice, bool correct)
    {
        
        Debug.Log("bowl is: " + bowl.name);
        Debug.Log("bowl is: " + bowl.tag);
        Debug.Log("bowl is: " + bowl.layer);

        //pourAnimationObject.SetActive(true);
        //StartCoroutine(PlayAnimationAndDelay(5, bowl));

        if (choice == 0)
        {
            if(correct == true)
            {
                pourAnimationObject[0].SetActive(true);
                StartCoroutine(PlayAnimationAndDelay(5, bowl, 0, 0));
            }
            else
            {
                pourAnimationObject[0].SetActive(true);
                StartCoroutine(PlayAnimationAndDelay(5, bowl, 0, 3));
            }
        }
        if(choice == 1)
        {
            if(correct == true)
            {
                pourAnimationObject[1].SetActive(true);
                StartCoroutine(PlayAnimationAndDelay(5, bowl, 1, 1));
            }
            else
            {
                pourAnimationObject[1].SetActive(true);
                StartCoroutine(PlayAnimationAndDelay(5, bowl, 1, 3));
            }
        }
        if(choice == 2 | choice == 3)
        {
            if(correct == true)
            {
                pourAnimationObject[2].SetActive(true);
                StartCoroutine(PlayAnimationAndDelay(5, bowl, 2, 2));
            }
            else
            {
                pourAnimationObject[2].SetActive(true);
                StartCoroutine(PlayAnimationAndDelay(5, bowl, 2, 3));
            }
        }

    }

    IEnumerator PlayAnimationAndDelay(int time, GameObject bowl, int animationChoice, int bowlChoice)
    {
        yield return new WaitForSeconds(time);
        pourAnimationObject[animationChoice].SetActive(false);

        Destroy(bowl);
        bowl = Instantiate(newPrefab[bowlChoice]);
        bowl.transform.position = placeSpot.position;
        bowl.transform.parent = transform;

        Debug.Log("bowl2 is: " + bowl.name);
        Debug.Log("bowl2 is: " + bowl.tag);
        Debug.Log("bowl2 is: " + bowl.layer);
    }


}
