using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] Animator anim;
    [SerializeField] public GameManager gameManager;

    private float horizInput;           // store horizontal input for used in FixedUpdate()
    private float moveSpeed = 450.0f;   // 4.5 * 100 newtons

    private float jumpHeight = 3.0f;    // height of jump in units
    private float jumpTime = 0.75f;     // time of jump in seconds
    private float initialJumpVelocity;  // calculated jump velocity

    private bool isGrounded = false;                        // true if player is grounded
    [SerializeField] private Transform groundCheckPoint;    // draw a circle around this to check ground
    [SerializeField] private LayerMask groundLayerMask;     // a layer for all things ground
    private float groundCheckRadius = 0.3f;                 // radius of ground check circle

    private int jumpMax = 1;            // # of jumps player can do without touching ground
    private int jumpsAvailable = 0;     // current jumps available to player

    public int health;
    public int maxHealth = 1400;

    private bool facingRight = true;    // true if facing right

    private void Start()
    {
        health = maxHealth;

        // calculate gravity using gravity formula
        float timeToApex = jumpTime / 2.0f;
        float gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);

        // adjust gravity scale of player based on gravity required for jumpHeight & jumpTime
        rbody.gravityScale = gravity / Physics2D.gravity.y;

        // calculate jump velocity req'd for jumpHeight & jumpTime
        initialJumpVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    void Update()
    {
        // read & store horizontal input
        horizInput = Input.GetAxis("Horizontal");

        // determine if player is running (for animator param)
        bool isWalking = horizInput > 0.01 || horizInput < -0.01;
        anim.SetBool("isWalking", isWalking);

        // determine if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask) && rbody.velocity.y < 0.01;
        anim.SetBool("isGrounded", isGrounded);

        // reset jumps if grounded
        if (isGrounded)
        {
            jumpsAvailable = jumpMax;
        }

        // if jump is triggered & available - go for it
        if (Input.GetButtonDown("Jump") && jumpsAvailable > 0)
        {
            Jump();
        }

        // flip player if appropriate
        if ((facingRight && horizInput < -0.01) ||
            (!facingRight && horizInput > 0.01))
        {
            Flip();
        }

        // check if player has fallen off level
        if (rbody.transform.position.y < -12)
        {
            health = 0;
            FindObjectOfType<AudioManager>().Play("death");
            gameManager.Death();
        }
        
    }

    private void OnDrawGizmos()
    {
        // draw the ground check sphere in the Scene
        Gizmos.DrawSphere(groundCheckPoint.position, groundCheckRadius);
    }

    private void FixedUpdate()
    {
        // move the player (use horizontal input, but maintain existing y velocity)
        float xVel = horizInput * moveSpeed * Time.deltaTime;
        rbody.velocity = new Vector2(xVel, rbody.velocity.y);
    }

    void Jump()
    {
        // tell the player to jump
        rbody.velocity = new Vector2(rbody.velocity.x, initialJumpVelocity);
        jumpsAvailable--;
        anim.SetTrigger("jump");
        FindObjectOfType<AudioManager>().Play("jump");
    }

    void Flip()
    {
        // flip the direction the player is facing
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180);
    }

    public void Hit(int damageDone)
    {
        health -= damageDone;
        FindObjectOfType<AudioManager>().Play("hit");

        if (health <= 0)
        {
            health = 0;
            FindObjectOfType<AudioManager>().Play("death");
            gameManager.Death();
        }
    }
}
