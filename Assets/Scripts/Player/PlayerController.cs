using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SO_PlayerSetup playerSetup;
    public Animator currentPlayer;
    
    private bool jump;
    private Rigidbody2D rb2D;
    private int jumpCount = 0;
    //private bool isGrounded;
    private float currentSpeed;

    private void OnValidate()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        currentPlayer = Instantiate(playerSetup.animator, transform);
    }
    private void FixedUpdate()
    {
        HandleJump();
        HandleMovement();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = playerSetup.speedRun;
        }
        else currentSpeed = playerSetup.speed;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < playerSetup.jumpsAmount)
        {
            jump = true;
        }
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.velocity = new Vector2(-currentSpeed, rb2D.velocity.y);
            currentPlayer.SetBool(playerSetup.runParam, true);
            rb2D.transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = new Vector2(currentSpeed, rb2D.velocity.y);
            currentPlayer.SetBool(playerSetup.runParam, true);
            rb2D.transform.localScale = new Vector2(1, 1);
        }
        else 
        {
            currentPlayer.SetBool(playerSetup.runParam, false);
        }

        // Applying manual friction
        if (rb2D.velocity.x > playerSetup.manualFriction)
        {
            rb2D.velocity -= new Vector2(playerSetup.manualFriction, 0);
        }
        else if (rb2D.velocity.x < -playerSetup.manualFriction)
        {
            rb2D.velocity += new Vector2(playerSetup.manualFriction, 0);
        }
    }
    private void HandleJump()
    {
        currentPlayer.SetFloat("JumpHeight", rb2D.velocity.y);
        if (jump)
        {
            rb2D.velocity = playerSetup.jumpForce * Vector2.up;
            jumpCount++;
            jump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            currentPlayer.SetTrigger(playerSetup.groundParam);
            //isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = false;
        }
    }
}