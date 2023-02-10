using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed;
    public float speedRun;
    public float jumpForce;
    [Min(1)]
    public int jumpsAmount;

    private Rigidbody2D rb2D;
    private float currentSpeed;
    //private bool isGrounded;
    private bool jump;
    private int jumpCount = 0;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
            currentSpeed = speedRun;
        }
        else currentSpeed = speed;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpsAmount)
        {
            jump = true;
        }
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.velocity = new Vector2(-currentSpeed, rb2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = new Vector2(currentSpeed, rb2D.velocity.y);
        }
        if (rb2D.velocity.x > .1f)
        {
            rb2D.velocity -= new Vector2(.1f, 0);
        }
        else if (rb2D.velocity.x < -.1f)
        {
            rb2D.velocity += new Vector2(.1f, 0);
        }
    }
    private void HandleJump()
    {
        if (jump)
        {
            rb2D.velocity = jumpForce * Vector2.up;
            jumpCount++;
            jump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
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