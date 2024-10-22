using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SO_PlayerSetup playerSetup;
    public SO_Keybinds keybinds;
    public Animator currentPlayer;
    [Header("VFX")]
    public ParticleSystem footParticles;
    public ParticleSystem jumpParticles;

    private Rigidbody2D rb2D;
    private float currentSpeed;
    private bool jump;
    private int jumpCount;
    private AudioSource jumpSound;
    private float distFromGround;

    private void OnValidate()
    {
        jumpSound = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        currentPlayer = Instantiate(playerSetup.animator, transform);
    }
    private void Start()
    {
        ResetJumpAmount();
        distFromGround = GetComponent<Collider2D>().bounds.extents.y;
        currentPlayer.SetBool(playerSetup.jumpingParam, false);
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
        if (Input.GetKey(keybinds.sprint))
        {
            currentSpeed = playerSetup.speedRun;
        }
        else currentSpeed = playerSetup.speed;

        if (Input.GetKeyDown(keybinds.jump) && jumpCount < playerSetup.jumpsAmount)
        {
            jump = true;
        }
        OnGroundAnimation();
    }
    private void HandleMovement()
    {
        bool _running = false;
        if (Input.GetKey(keybinds.moveLeft))
        {
            rb2D.velocity = new Vector2(-currentSpeed, rb2D.velocity.y);
            _running = true;
            rb2D.transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(keybinds.moveRight))
        {
            rb2D.velocity = new Vector2(currentSpeed, rb2D.velocity.y);
            _running = true;
            rb2D.transform.localScale = new Vector2(1, 1);
        }
        footParticles.gameObject.SetActive(_running);
        currentPlayer.SetBool(playerSetup.runParam, _running);

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
            jumpParticles.Play();
            jumpSound.Play();
            currentPlayer.SetBool(playerSetup.jumpingParam, true);
            jump = false;
        }
    }
    private void ResetJumpAmount()
    {
        jumpCount = 0;
    }
    private bool OnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distFromGround * .1f);
    }
    private void OnGroundAnimation()
    {
        currentPlayer.SetBool(playerSetup.groundParam, OnGround());
        
        if (OnGround())
        {
            currentPlayer.SetBool(playerSetup.jumpingParam, false);
        }
    }
}