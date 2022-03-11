using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public AudioSource throwSound;
    public BallCollectable ballCollectable;
    public CharacterMovement playerMovement;
    public PickUpBall pickUp;
    public GameObject Camera;
    public float throwForce;

    // Start is called before the first frame update
    void Start()
    {
        ballCollectable.GetComponent<BallCollectable>();
        pickUp.GetComponent<PickUpBall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && pickUp.isHolding)
        {
            throwSound.Play();
            ballCollectable.ball.transform.parent = null;
            pickUp.isHolding = false;
            ballCollectable.ball.GetComponent<Rigidbody>().isKinematic = false;

            ballCollectable.ball.GetComponent<Rigidbody>().AddForce(Camera.transform.forward * throwForce * playerMovement.velocitySpeed / 2, ForceMode.Impulse);
        }
    }
}
