using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    [SerializeField] GameObject thisCatPost;
    [SerializeField] BoolAssetValue isFirstStage;

    private GameObject waypointObject;
    private Transform currentWaypoint;
    private int currentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        waypoints[0] = GameObject.Find("Waypoint1").transform;
        waypoints[1] = GameObject.Find("Waypoint2").transform;
        waypoints[2] = GameObject.Find("Waypoint3").transform;
        waypoints[3] = GameObject.Find("Waypoint4").transform;
        waypoints[4] = GameObject.Find("Waypoint5").transform;
        transform.position = waypoints[0].position;
        /*  
        for (int i = 0; i < waypoints.Length; i++)
        {
            string waypointName = "Waypoint" + i;
            Debug.Log(waypointName);
            waypointObject = GameObject.Find(waypointName);
            waypoints[i] = waypointObject.transform;
        }
        */
        currentWaypointIndex = 0;
        currentWaypoint = waypoints[currentWaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (thisCatPost.CompareTag("CatPostMoving"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
            {
                //Reached the waypoint
                isFirstStage.value = false;
                if (isFirstStage.value == true)
                {
                    //Check to see if there are more waypoints
                    if (currentWaypointIndex + 1 < waypoints.Length)
                    {
                        currentWaypointIndex++;
                    }
                    else
                    {
                        Destroy(thisCatPost);
                    }
                }
                else if(isFirstStage.value == false)
                {
                    if (currentWaypointIndex + 1 < waypoints.Length - 2)
                    {
                        currentWaypointIndex++;
                    }
                    else
                    {
                        thisCatPost.transform.position = waypoints[2].transform.position;
                    }
                }

                

                currentWaypoint = waypoints[currentWaypointIndex];

                //Go towards next waypoint

                //Find the direction vector that points to the next waypoint
                Vector3 waypointDirection = currentWaypoint.position - transform.position;
                //Find the rotation in degrees 
                float angle = Mathf.Atan2(waypointDirection.y, waypointDirection.x) * Mathf.Rad2Deg - 180;
                //Find the rotation
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                //Apply the rotation
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
            }
        }
    }
}
