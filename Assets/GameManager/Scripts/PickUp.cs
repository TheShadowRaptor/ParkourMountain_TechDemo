using UnityEngine;

public class PickUp : MonoBehaviour
{
    // initilize destination
    private Transform theDest;   
    public GameObject player;    

    //pickUp checking
    public float pickUpDistance = 1f;
    public LayerMask pickUpMask;

    public bool canPickUp = false;
    public bool isHolding = false;

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
    }
}
