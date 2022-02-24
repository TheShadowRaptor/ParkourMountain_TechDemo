using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Moving
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Vector3 velocity;

    //Jumping
    public float wallJumpHeight = 1;
    public float jumpHeight = 3;

    //ground checking
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //wall checking
    public Transform wallCheck;
    public float wallDistance = 0.4f;
    public LayerMask wallOneMask;
    public LayerMask wallTwoMask;

    //vault checking
    public Transform vaultCheck;
    public float vaultDistance = 0.4f;
    public LayerMask vaultMask;

    private bool isGrounded;
    private bool canWallJumpOne;
    private bool canWallJumpTwo;
    /*private bool canVault;*/

    private bool oneTimeWallJumpOne;
    private bool oneTimeWallJumpTwo;
    /*private bool oneTimeVaultJump;*/

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
            oneTimeWallJumpOne = true;
            oneTimeWallJumpTwo = true;
            /*oneTimeVaultJump = true;*/
        }

        // Rest wall jump
        if (canWallJumpTwo) oneTimeWallJumpOne = true;
        if (canWallJumpOne) oneTimeWallJumpTwo = true;

        //Checks if player can walljump
        canWallJumpOne = Physics.CheckSphere(wallCheck.position, wallDistance, wallOneMask);
        canWallJumpTwo = Physics.CheckSphere(wallCheck.position, wallDistance, wallTwoMask);

        if (canWallJumpOne && velocity.x < 0) velocity.x = 0;

        if (canWallJumpTwo && velocity.x < 0) velocity.x = 0;

        //Checks if player is near a vault
        /*canVault = Physics.CheckSphere(vaultCheck.position, vaultDistance, vaultMask);*/

        //Jump Input
        if (isGrounded && Input.GetButtonDown("Jump")) velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);      

        //Wall Jump
        if (canWallJumpOne && Input.GetButtonDown("Jump") && oneTimeWallJumpOne == true)
        {
            velocity.y = Mathf.Sqrt(wallJumpHeight * -1f * gravity);
            oneTimeWallJumpOne = false;
        }

        if (canWallJumpTwo && Input.GetButtonDown("Jump") && oneTimeWallJumpTwo == true)
        {
            velocity.y = Mathf.Sqrt(wallJumpHeight * -1f * gravity);
            oneTimeWallJumpTwo = false;
        }

        /* //Vaulting
         *//*if (canVault && Input.GetButtonDown("Jump") && oneTimeVaultJump == true)
         {
             //can vault
             //speed = speed + 100;
             oneTimeVaultJump = false;*//*
         }     */
    }    
}
