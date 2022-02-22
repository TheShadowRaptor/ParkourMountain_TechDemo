using UnityEngine;

public class PickUp : MonoBehaviour
{
    // initilize destination
    private Transform theDest;

    public GameObject ball;

    //pickUp checking
    public float pickUpDistance = 1f;
    public LayerMask pickUpMask;

    public bool canPickUp = false;
    public bool isPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        theDest = GameObject.FindWithTag("Dest").transform;
    }

    private void Update()
    {
        //Check if looking at ball
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpDistance, pickUpMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            canPickUp = true;
        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * pickUpDistance, Color.green);
            canPickUp = false;
        }

        //Pick up ball
        if (Input.GetMouseButtonDown(0) && canPickUp == true)
        {
            Debug.Log("pickup");
            ball.transform.position = theDest.position;
            ball.transform.parent = theDest;
            isPickedUp = true;
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }

        else if (Input.GetMouseButtonDown(0) && isPickedUp == true)
        {
            Debug.Log("pickup");
            ball.transform.parent = null;
            isPickedUp = false;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            ball.GetComponent<Rigidbody>().AddForce(Vector3.forward);

        }
    }
}
