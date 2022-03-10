using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject dest;
    public GameObject player;
    public BallCollectable ballCollectable;
    public CharacterController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.enabled = false;
            player.transform.position = dest.transform.position;
            controller.enabled = true;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            ballCollectable.ball.transform.position = dest.transform.position;
        }
    }
}
