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

    [SerializeField] private OrbitObjectsActiveAssetValue activeOrbit;

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

        if (activeOrbit.currentActiveOrbit == OrbitsActive.farActive)
        {
            if (collision.gameObject.name == "CatObjectFar(Clone)" && gameObject.name == "OrbitFar(Clone)")
            {
                Debug.Log("Char Matched: " + collision.gameObject.name + " and " + gameObject);
                MatchedObjects(collision.gameObject);
            }
            else
            {
                Debug.Log("No match");
                Destroy(collision.gameObject);
            }
        }
        else if (activeOrbit.currentActiveOrbit == OrbitsActive.outerActive)
        {
            if (collision.gameObject.name == "CatObjectOuter(Clone)" && gameObject.name == "OrbitOuter(Clone)")
            {
                Debug.Log("Bool Matched: " + collision.gameObject.name + " and " + gameObject);
                MatchedObjects(collision.gameObject);
            }
            else
            {
                Debug.Log("No match");
                Destroy(collision.gameObject);
            }
        }
        else if (activeOrbit.currentActiveOrbit == OrbitsActive.midActive)
        {
            if (collision.gameObject.name == "CatObjectMid(Clone)" && gameObject.name == "OrbitMid(Clone)")
            {
                Debug.Log("Int Matched: " + collision.gameObject.name + " and " + gameObject);
                MatchedObjects(collision.gameObject);
            }
            else
            {
                Debug.Log("No match");
                Destroy(collision.gameObject);
            }
        }
        else if(activeOrbit.currentActiveOrbit == OrbitsActive.innerActive)
        {
            if (collision.gameObject.name == "CatObjectInner(Clone)" && gameObject.name == "OrbitInner(Clone)")
            {
                Debug.Log("Float Matched: " + collision.gameObject.name + " and " + gameObject);
                MatchedObjects(collision.gameObject);
            }
            else
            {
                Debug.Log("No match");
                Destroy(collision.gameObject);
            }
        }
    }

    public void MatchedObjects(GameObject collisionObject)
    {
        Destroy(collisionObject);
        gameObject.transform.localScale = new Vector3(0, 0, 0);

    }
}
