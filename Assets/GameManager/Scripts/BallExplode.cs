using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplode : MonoBehaviour
{
    public BallCollectable ballCollectable;
    public Collectable collectable;
    // Start is called before the first frame update
    void Start()
    {
        ballCollectable.GetComponent<BallCollectable>();
        collectable.GetComponent<Collectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballCollectable.ball.transform.position != ballCollectable.theDest.position)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ballCollectable.ball.SetActive(false);
                collectable.collected = false;
            }
        }
    }
}
