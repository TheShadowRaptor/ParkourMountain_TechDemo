using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public Respawn respawn;
    public BallCollectable ballCollectable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) respawn.activated = true;

        if (other.gameObject.CompareTag("Ball")) ballCollectable.ball.SetActive(false);
    }
}
