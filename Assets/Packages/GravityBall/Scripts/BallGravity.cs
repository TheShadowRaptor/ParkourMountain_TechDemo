using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    public PickUpBall pickUpBall;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Vector3 velocity;

    public float gravity = -9.81f;
    public float groundDistance = 0.4f;

    private bool isGrounded;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            velocity.y = -2f;
        }
        if (pickUpBall.isHolding)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        
        if(pickUpBall.isHolding == false)
        {
            rb.AddForce(0, velocity.y, 0);
        }        
    }
}
