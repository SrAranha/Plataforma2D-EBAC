using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed;
    public float speedRun;
    public float jumpForce;

    private float currentSpeed;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speedRun;
        }
        else currentSpeed = speed;
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.velocity = currentSpeed * Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = currentSpeed * Vector2.right;
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
}