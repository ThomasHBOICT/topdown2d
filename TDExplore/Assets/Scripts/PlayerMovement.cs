using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Vector2 movement;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

       // animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
        }
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }

        animator.SetFloat("speed", System.Math.Abs(movement.x));

        animator.SetFloat("speedY", movement.y);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
}
