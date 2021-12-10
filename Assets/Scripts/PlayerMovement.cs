using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    private Animator animator;
    private PickUp pickUp;

    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        transform.position = startingPosition.initialValue;
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change.sqrMagnitude > .5f)
        {
            pickUp.Direction = change.normalized;
        }

        UpdateAnimationAndMove();
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.fixedDeltaTime
            );
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
}
