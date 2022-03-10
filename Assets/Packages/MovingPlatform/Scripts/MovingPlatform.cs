using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject player;
    public BallCollectable ballCollectable;
    public GameObject sphere;

    public Transform target;
    public Transform targetHolder;
    public float speed;

    private Vector3 start;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        targetHolder.position = target.position;
        step = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            target.position = start;
            start = targetHolder.position;
            targetHolder.position = target.position;
        }      
    }

    private void OnTriggerStay(Collider other)
    {
        Physics.autoSyncTransforms = true;
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = transform;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            ballCollectable.ball.transform.parent = sphere.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            ballCollectable.ball.transform.parent = null;
        }
    }

}
