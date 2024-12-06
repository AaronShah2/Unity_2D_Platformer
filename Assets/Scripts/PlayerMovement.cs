using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float extraJumps = 1;

    public float jumpDeacceleration = 0.5f;
    [SerializeField] Transform feet;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    // variables for ground check
    public float GroundCheckRadius = 0.2f;

    // Variable for extra jumps
    int jumpCount = 0;
    float jumpCooldown;

    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement 
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Mechanic to increase if button is held down
        if (Input.GetButtonUp("Jump")  && rb.linearVelocityY > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocityY * jumpDeacceleration);
        }

        CheckGrounded();
    }

    void Jump(){
        if(isGrounded || jumpCount < extraJumps ){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
        }
    }

    void CheckGrounded() {
        if(Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.2f;
        } else if (Time.time <  jumpCooldown){
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
}
