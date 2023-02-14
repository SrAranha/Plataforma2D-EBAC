using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed;
    public float speedRun;
    public float manualFriction;
    public float jumpForce;
    [Min(1)]
    public int jumpsAmount;

    [Header("Animation")]
    public string runParam;
    public string jumpParam;
    public string groundParam;
    
    private bool jump;
    private Rigidbody2D rb2D;
    private int jumpCount = 0;
    private Animator animator;
    //private bool isGrounded;
    private float currentSpeed;

    private void OnValidate()
    {
        animator = GetComponentInChildren<Animator>();
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
            animator.SetBool(runParam, true);
            rb2D.transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = new Vector2(currentSpeed, rb2D.velocity.y);
            animator.SetBool(runParam, true);
            rb2D.transform.localScale = new Vector2(1, 1);
        }
        else 
        {
            animator.SetBool(runParam, false);
        }

        // Applying manual friction
        if (rb2D.velocity.x > manualFriction)
        {
            rb2D.velocity -= new Vector2(manualFriction, 0);
        }
        else if (rb2D.velocity.x < -manualFriction)
        {
            rb2D.velocity += new Vector2(manualFriction, 0);
        }
    }
    private void HandleJump()
    {
        animator.SetFloat("JumpHeight", rb2D.velocity.y);
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
            animator.SetTrigger(groundParam);
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