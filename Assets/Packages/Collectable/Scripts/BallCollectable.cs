using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollectable : Collectable
{  
    Color color;

    public Transform theDest;

    public GameObject ball;

    public PickUp pickUp;

    public Renderer ObjectRenderer;
    public Collider ObjectCollider;
    public Material material;

    public float alpha;

    public Collectable collectable;

    bool objectActive;
    bool ballSpawned;
    // Start is called before the first frame update
    void Start()
    {      
        theDest = GameObject.FindWithTag("Dest").transform;
        collectable.GetComponent<Collectable>();
        ObjectRenderer.GetComponent<Renderer>();
        color = material.color;
        GetObjectComponents(ObjectRenderer, ObjectCollider);
    }

    // Update is called once per frame
    void Update()
    {
        //object uncollectable if ball is present on scene
        if (GameObject.Find("GravityBall(Clone)") != null) 
        {
            alpha = -1.5f;
            ChangeObjectsMaterial(material, alpha);
            objectActive = true;
            collected = false;
        }
        else
        {
            alpha = 0.5f;
            ChangeObjectsMaterial(material, alpha);                
            objectActive = false;
        }

        /*//collectable respawn
        TimeToRespawn(ObjectRenderer, ObjectCollider);*/

        //spawns ball on players hand
        if (collected == true && objectActive == false)
        {           
            //Instatiate Once
            if (ballSpawned == false)
            {
                ball = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            }           
            else if (ballSpawned == true)
            {
                ball.SetActive(true);
            }
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.position = theDest.position;
            ball.transform.parent = theDest;
            ballSpawned = true;
            pickUp.isHolding = true;

            if (pickUp.isHolding == true && Input.GetMouseButtonDown(0))
            {                
                ball.GetComponent<Rigidbody>().isKinematic = false;
                pickUp.isHolding = false;
            }

            //Pick up ball
            if (Input.GetMouseButtonDown(0) && pickUp.canPickUp == true)
            {
                ball.transform.position = theDest.position;
                ball.transform.parent = theDest;
                ball.GetComponent<Rigidbody>().isKinematic = true;
                pickUp.isHolding = true;
            }
            
        }      
    }

    private void OnTriggerStay(Collider other)
    {
        ObjectCollected(other, ObjectRenderer, ObjectCollider);
    }

    protected void ChangeObjectsMaterial(Material material, float alpha)
    {
        color = material.color;
        color.a = alpha;
        material.color = color;
    }
}
