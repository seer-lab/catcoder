using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    [SerializeField] GameObject thisCatPost;
    [SerializeField] DialogueStateAssetValue thisStage;

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

        currentWaypointIndex = 0;
        currentWaypoint = waypoints[currentWaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (thisCatPost.CompareTag("CatPostMoving"))
        {
            if(thisStage.currentStage == StageValues.stage1)
            {
                speed = 2f;
            }
            else if (thisStage.currentStage == StageValues.stage1a || thisStage.currentStage == StageValues.stage2a || thisStage.currentStage == StageValues.stage3a)
            {
                speed = 4f;
            }
            else
            {
                speed = 1.5f;
            }

            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
            {
                //Reached the waypoint
                if (thisStage.currentStage == StageValues.stage1 || thisStage.currentStage == StageValues.stage1a || thisStage.currentStage == StageValues.stage2 || thisStage.currentStage == StageValues.stage2a)
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
                else if(thisStage.currentStage == StageValues.stage3 || thisStage.currentStage == StageValues.stage3a || thisStage.currentStage == StageValues.stage4)
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
