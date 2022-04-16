using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;

    private Rigidbody2D rb;

    private float horizontal, vertical;

    //Limits diagnol movement
    private float moveLimiter = 0.7f;

    public float MoveSpeed;

    private SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        else if (horizontal < 0)
        {
            sr.flipX = true;
        }
    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            Vector2 newVel = new Vector2(horizontal * MoveSpeed, vertical * MoveSpeed);

            if (newVel != Vector2.zero)
            {
                //rb.velocity = newVel;
                rb.AddForce(newVel);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }
}