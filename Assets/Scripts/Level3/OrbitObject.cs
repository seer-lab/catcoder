using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float radius;
    [SerializeField] GameObject catnipObjects;

    [SerializeField] Vector2 centrePoint;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        centrePoint = GameObject.FindGameObjectWithTag("BossObject").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += rotationSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = centrePoint + offset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision" + collision.transform.name);

        if (collision.gameObject.name == "CatnipChar(Clone)" && gameObject.name == "OrbitFar(Clone)")
        {
            Debug.Log("Char Matched: " + collision.gameObject.name + " and " + gameObject);
            MatchedObjects(collision.gameObject);
        }
        else if (collision.gameObject.name == "CatnipBool(Clone)" && gameObject.name == "OrbitOuter(Clone)")
        {
            Debug.Log("Bool Matched: " + collision.gameObject.name + " and " + gameObject);
            MatchedObjects(collision.gameObject);
        }
        else if (collision.gameObject.name == "CatnipInt(Clone)" && gameObject.name == "OrbitMid(Clone)")
        {
            Debug.Log("Int Matched: " + collision.gameObject.name + " and " + gameObject);
            MatchedObjects(collision.gameObject);
        }
        else if (collision.gameObject.name == "CatnipFloat(Clone)" && gameObject.name == "OrbitInner(Clone)")
        {
            Debug.Log("Float Matched: " + collision.gameObject.name + " and " + gameObject);
            MatchedObjects(collision.gameObject);
        }
        else
        {
            Debug.Log("No match");
            Destroy(collision.gameObject);
        }
        //collision.gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void MatchedObjects(GameObject collisionObject)
    {
        Destroy(collisionObject);
        Destroy(gameObject);
    }
}
