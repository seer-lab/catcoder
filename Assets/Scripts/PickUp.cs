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
    private LayerMask allCollisions;


    private void Start()
    {
        allCollisions = pickUpMask | wallCollisionMask | objectCollisionMask;
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
            //If there is currently an item being held; drop procedure
            if (itemHolding)
            {
                if(hit.collider == null)
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
}
