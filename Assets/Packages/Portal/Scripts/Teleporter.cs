using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject dest;
    public GameObject player;
    public BallCollectable ballCollectable;
    public PickUpBall pickUpBall;
    public CharacterController controller;
    public AudioSource warp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.enabled = false;
            player.transform.position = dest.transform.position;
            controller.enabled = true;
            warp.Play();
        }

        if (other.gameObject.CompareTag("Ball") && pickUpBall.ballCollectable.theDest.transform.position != pickUpBall.ballCollectable.ball.transform.position)
        {
            ballCollectable.ball.transform.position = dest.transform.position;
        }
    }
}
