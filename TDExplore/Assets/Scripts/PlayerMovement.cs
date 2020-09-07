using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Vector2 movement;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        Run();

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
            //transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
            renderer.flipX = true;
        }
        if (movement.x < 0)
        {
            //transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            renderer.flipX = false;
        }

        animator.SetFloat("speed", System.Math.Abs(movement.x));

        animator.SetFloat("speedY", movement.y);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed += 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed -= 5;
        }
    }
}
