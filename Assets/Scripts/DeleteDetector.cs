using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDetector : MonoBehaviour
{

    public Transform deleteSpot;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "TransformedObject" && !other.isTrigger)
        {
            Debug.Log("here");
            other.transform.position = deleteSpot.position;
            other.transform.parent = transform;
            //Set time respawn to 5 seconds
            StartCoroutine(Delete(other, 5));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Delete(Collider2D other, int time)
    {
        yield return new WaitForSeconds(time);

        Destroy(other.gameObject);
        Debug.Log("Deleting!");
        Debug.Log(other);
    }


}
