using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Moving
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    //Jumping

    public float jumpHeight = 3;

    //ground checking
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //wall checking
    public Transform wallCheck;
    public float wallDistance = 0.4f;
    public LayerMask wallMask;

    //vault checking
    public Transform vaultCheck;
    public float vaultDistance = 0.4f;
    public LayerMask vaultMask;

    private bool isGrounded;
    private bool canWallJump;
    private bool canVault;

    private bool oneTimeWallJump;
    private bool oneTimeVaultJump;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    public void PlayerMovement()
    {
        //Moves Player--------------------------------
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Gives the player gravity---------------------
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    public void PlayerJump()
    {       

    //Checks if player is on the ground------------
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            oneTimeWallJump = true;
            oneTimeVaultJump = true;
        }

        //Checks if player can walljump
        canWallJump = Physics.CheckSphere(wallCheck.position, wallDistance, wallMask);

        if (canWallJump && velocity.x < 0)
        {
            velocity.x = 0;
        }

        //Checks if player is near a vault
        canVault = Physics.CheckSphere(vaultCheck.position, vaultDistance, vaultMask);

        //Jump Input
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        //Wall Jump
        if (canWallJump && Input.GetButtonDown("Jump") && oneTimeWallJump == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
            oneTimeWallJump = false;
        }

        //Vaulting
        /*if (canVault && Input.GetButtonDown("Jump") && oneTimeVaultJump == true)
        {
            //can vault
            //speed = speed + 100;
            oneTimeVaultJump = false;*/
        }        
    }    
}
