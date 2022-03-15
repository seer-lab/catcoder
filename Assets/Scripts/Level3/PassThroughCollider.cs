using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughCollider : MonoBehaviour
{
    [SerializeField] string ignoreThisTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ignoreThisTag)
        {
            Debug.Log(collision.collider);
            Debug.Log(gameObject.GetComponent<CircleCollider2D>());
            //Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<CircleCollider2D>());
        }
    }
}
