using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SO_PlayerSetup playerSetup;
    public Animator currentPlayer;
    
    private Rigidbody2D rb2D;
    private float currentSpeed;
    private bool jump;
    private int jumpCount;
    private float distFromGround;

    private void OnValidate()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        ResetJumpAmount();
        currentPlayer = Instantiate(playerSetup.animator, transform);
        distFromGround = GetComponent<Collider2D>().bounds.extents.y;
    }
    private void FixedUpdate()
    {
        if (OnGround())
        {
            ResetJumpAmount();
        }
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
        currentPlayer.SetFloat(playerSetup.jumpParam, rb2D.velocity.y);
        if (jump)
        {
            rb2D.velocity = playerSetup.jumpForce * Vector2.up;
            jumpCount++;
            jump = false;
        }
    }
    private void ResetJumpAmount()
    {
        jumpCount = 1;
    }
    private bool OnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distFromGround * .3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && OnGround())
        {
            currentPlayer.SetTrigger(playerSetup.groundParam);
        }
    }
}