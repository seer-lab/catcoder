using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public LayerMask wallCollisionMask;
    public LayerMask objectCollisionMask;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;
    private List<GameObject> itemHoldingMulti;
    private LayerMask allCollisions;

    [SerializeField] private OrbitObjectsActiveAssetValue activeOrbit;
    [SerializeField] private BoolAssetValue numberThrown;

    [SerializeField] private CurrentLevelValue currentLevel;

    private void Start()
    {
        allCollisions = pickUpMask | wallCollisionMask | objectCollisionMask;
        itemHoldingMulti = new List<GameObject>();
        numberThrown.value = false;
    }
    // Update is called once per frame
    void Update()
    {
        Ray2D ray = new Ray2D(transform.position, Direction);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1f, allCollisions); 

        if(hit.collider != null)
        {
            //Debug.Log("hit something!");
            //Debug.Log(hit.collider.name);
            Debug.DrawLine(ray.origin, hit.point);
        }

        //When the key E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentLevel.currentLevel == LevelValues.level1_3)
            {

                //If there is currently an item being held; drop procedure
                if (itemHolding && !(activeOrbit.currentActiveOrbit == OrbitsActive.farActive ||
                                activeOrbit.currentActiveOrbit == OrbitsActive.outerActive ||
                                activeOrbit.currentActiveOrbit == OrbitsActive.midActive ||
                                activeOrbit.currentActiveOrbit == OrbitsActive.innerActive))
                {
                    Debug.Log("Not level 3 and item being held");
                    if (hit.collider == null)
                    {
                        itemHolding.transform.position = transform.position + Direction;
                        itemHolding.transform.parent = null;
                        if (itemHolding.GetComponent<Rigidbody2D>())
                        {
                            itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                        }
                        itemHolding = null;
                    }

                }
                //Else pickup procedure
                else
                {
                    Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                    if (pickUpItem)
                    {
                        if (activeOrbit.currentActiveOrbit == OrbitsActive.farActive)
                        {
                            if (pickUpItem.tag == "Catnip1")
                            {
                                itemHolding = pickUpItem.gameObject;
                                itemHolding.transform.position = holdSpot.position;
                                itemHolding.transform.parent = transform;

                                if (itemHolding.GetComponent<Rigidbody2D>())
                                {
                                    itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                                }
                                itemHoldingMulti.Add(itemHolding);
                            }
                            else
                            {
                                Debug.Log("Can only pick up Cat Head now");
                            }
                        }
                        else if (activeOrbit.currentActiveOrbit == OrbitsActive.outerActive)
                        {
                            if (pickUpItem.tag == "Catnip2")
                            {
                                itemHolding = pickUpItem.gameObject;
                                itemHolding.transform.position = holdSpot.position;
                                itemHolding.transform.parent = transform;
                                if (itemHolding.GetComponent<Rigidbody2D>())
                                {
                                    itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                                }
                                itemHoldingMulti.Add(itemHolding);
                            }
                            else
                            {
                                Debug.Log("Can only pick up Cat Paw now");
                            }
                        }
                        else if (activeOrbit.currentActiveOrbit == OrbitsActive.midActive)
                        {
                            if (pickUpItem.tag == "Catnip3")
                            {
                                itemHolding = pickUpItem.gameObject;
                                itemHolding.transform.position = holdSpot.position;
                                itemHolding.transform.parent = transform;
                                if (itemHolding.GetComponent<Rigidbody2D>())
                                {
                                    itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                                }
                                itemHoldingMulti.Add(itemHolding);
                            }
                            else
                            {
                                Debug.Log("Can only pick up Cat body now");
                            }
                        }
                        else if (activeOrbit.currentActiveOrbit == OrbitsActive.innerActive)
                        {
                            if (pickUpItem.tag == "Catnip4")
                            {
                                itemHolding = pickUpItem.gameObject;
                                itemHolding.transform.position = holdSpot.position;
                                itemHolding.transform.parent = transform;
                                if (itemHolding.GetComponent<Rigidbody2D>())
                                {
                                    itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                                }
                                itemHoldingMulti.Add(itemHolding);
                            }
                            else
                            {
                                Debug.Log("Can only pick up Cat Eye now");
                            }
                        }
                        else
                        {
                            itemHolding = pickUpItem.gameObject;
                            itemHolding.transform.position = holdSpot.position;
                            itemHolding.transform.parent = transform;
                            if (itemHolding.CompareTag("CatPostMoving"))
                            {
                                itemHolding.tag = "CatPostHeld";
                            }
                            if (itemHolding.GetComponent<Rigidbody2D>())
                            {
                                itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (itemHolding)
                {
                    Debug.Log("Not level 3 and item being held");
                    if (hit.collider == null)
                    {
                        itemHolding.transform.position = transform.position + Direction;
                        itemHolding.transform.parent = null;
                        if (itemHolding.GetComponent<Rigidbody2D>())
                        {
                            itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                        }
                        itemHolding = null;
                    }

                }
                else
                {
                    Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                    if (pickUpItem)
                    {
                        itemHolding = pickUpItem.gameObject;
                        itemHolding.transform.position = holdSpot.position;
                        itemHolding.transform.parent = transform;
                        if (itemHolding.CompareTag("CatPostMoving"))
                        {
                            itemHolding.tag = "CatPostHeld";
                        }
                        if (itemHolding.GetComponent<Rigidbody2D>())
                        {
                            itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                        }
                    }
                }
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (itemHoldingMulti.Count >= 3)
            {
                Debug.Log("More than 3");
                numberThrown.value = true;
                /*
                List<GameObject> tempItems = new List<GameObject>();
                tempItems.Add(itemHoldingMulti[0]);
                tempItems.Add(itemHoldingMulti[1]);
                tempItems.Add(itemHoldingMulti[2]);

                foreach(var item in tempItems)
                {
                    item.transform.position = transform.position + Direction;
                    item.transform.parent = null;
                    item.GetComponent<Rigidbody2D>().simulated = true;
                    item.GetComponent<Rigidbody2D>().isKinematic = false;
                    item.GetComponent<Rigidbody2D>().AddForce(transform.position + Direction * 7500);
                    itemHoldingMulti.Remove(item);
                }
                */
                Destroy(itemHoldingMulti[1].gameObject);
                Destroy(itemHoldingMulti[2].gameObject);
                itemHoldingMulti.RemoveAt(2);
                itemHoldingMulti.RemoveAt(1);

                var tempItem = new GameObject();
                tempItem = itemHoldingMulti[0];
                tempItem.transform.position = transform.position + Direction;
                tempItem.transform.parent = null;
                tempItem.GetComponent<Rigidbody2D>().simulated = true;
                tempItem.GetComponent<Rigidbody2D>().isKinematic = false;
                tempItem.GetComponent<Rigidbody2D>().AddForce(transform.position + Direction * 7500);
                itemHoldingMulti.Remove(tempItem);
            }
            else if (itemHoldingMulti.Count != 0)
            {
                Debug.Log(itemHoldingMulti.Count);
                numberThrown.value = false;
                var tempItem = new GameObject();
                tempItem = itemHoldingMulti[0];
                tempItem.transform.position = transform.position + Direction;
                tempItem.transform.parent = null;
                tempItem.GetComponent<Rigidbody2D>().simulated = true;
                tempItem.GetComponent<Rigidbody2D>().isKinematic = false;
                tempItem.GetComponent<Rigidbody2D>().AddForce(transform.position + Direction * 7500);
                itemHoldingMulti.Remove(tempItem);
            }
        }
    }
}
