using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redcat_Walk : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private bool moveRight = false;

    RaycastHit2D hit;

    void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1.0f, groundLayer);
    }

    private void FixedUpdate() {
        if (hit.collider)
        {
            if (moveRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
        else 
        {
            moveRight = !moveRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1.0f);
        }
    }
}
