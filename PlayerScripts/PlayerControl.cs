using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigid;
    private bool isGrounded;
    private float coyoteTimeCounter;
    private float normalSpeed;
    private bool isDashing;
    private float dashTimeCounter;
    PlayerStamina stamina;


    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float playerJump;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float dashCost = 25f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float coyoteTime = 0.1f;
    



    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        normalSpeed = walkSpeed;
        stamina = GetComponent<PlayerStamina>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);
        playerAnimator.SetFloat("yVelocity", playerRigid.velocity.y);
        
        if(isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        playerRigid.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, playerRigid.velocity.y);
        float move = Mathf.Abs(Input.GetAxis("Horizontal"));
        if(Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetFloat("speed", move * 1f);  
        }
        else
        {
            playerAnimator.SetFloat("speed", move * 0.5f); 
        }


        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), (transform.localScale.y), (transform.localScale.z));
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), (transform.localScale.y), (transform.localScale.z));
        }

         if(Input.GetKeyDown(KeyCode.Space) &&  (isGrounded || coyoteTimeCounter > 0f))
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x,playerJump);
            playerAnimator.SetTrigger("jump");

        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = runSpeed;
            
        }
        else
        {
            walkSpeed = normalSpeed;
        }

        if (Input.GetMouseButtonDown(1) && !isDashing && isGrounded)
        {
            if (stamina.UseStamina(dashCost))
            {
            isDashing = true;
            dashTimeCounter = dashTime;
            playerAnimator.SetBool("isDashing", true);
            }
        }
        
        if (isDashing)
        {
            dashTimeCounter -= Time.deltaTime;
            float direction = transform.localScale.x > 0 ? 1 : -1;
            playerRigid.velocity = new Vector2(direction * dashSpeed, 0);

            if(dashTimeCounter <= 0)
            {
                isDashing = false;
                playerAnimator.SetBool("isDashing", false); 
            }
        
        return;
        }

        if (playerRigid.velocity.y < 0)
        {
            playerRigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        
        if (playerRigid.velocity.y > 0)
        {
            playerRigid.velocity += Vector2.up * Physics2D.gravity.y * 2f * Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
        {
            if (groundCheck == null) return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
}
