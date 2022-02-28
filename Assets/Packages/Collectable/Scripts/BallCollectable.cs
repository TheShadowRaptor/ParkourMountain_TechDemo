using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollectable : Collectable
{  
    Transform theDest;
    Color color;

    public GameObject ball;
    public PickUp pickUp;
    public Renderer ObjectRenderer;
    public Collider ObjectCollider;
    public Material material;

    public Collectable collectable;

    bool objectOn = true;
    // Start is called before the first frame update
    void Start()
    {      
        theDest = GameObject.FindWithTag("Dest").transform;
        collectable.GetComponent<Collectable>();
        ObjectRenderer.GetComponent<Renderer>();
        color.a = 2;
        GetObjectComponents(ObjectRenderer, ObjectCollider);
    }

    // Update is called once per frame
    void Update()
    {
        //object uncollectable if ball is present on scene
        if (GameObject.Find("GravityBall(Clone)") != null)
        {
            ChangeObjectsMaterial(material);
            objectOn = false;
        }

        //collectable respawn
        TimeToRespawn(ObjectRenderer, ObjectCollider);

        //spawns ball on players hand
        if (collected == true && objectOn)
        {
            ball = Instantiate(ball, new Vector3(0,0,0), Quaternion.identity) as GameObject;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.position = theDest.position;
            ball.transform.parent = theDest;
            pickUp.isHolding = true;

            if (pickUp.isHolding == true && Input.GetMouseButtonDown(0))
            {
                ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectCollected(other, ObjectRenderer, ObjectCollider);
    }

    protected void ChangeObjectsMaterial(Material material)
    {
        color = material.color;
        color.a = -1.5f;
        material.color = color;
    }
}
