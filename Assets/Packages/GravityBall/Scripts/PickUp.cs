using UnityEngine;

public class PickUp : MonoBehaviour
{
    // initilize destination
    private Transform theDest;
    

    public BallCollectable throwable;
    public GameObject Camera;
    public GameObject player;
    public CharacterMovement playerMovement;

    public float force;

    //pickUp checking
    public float pickUpDistance = 1f;
    public LayerMask pickUpMask;

    public bool canPickUp = false;
    public bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        theDest = GameObject.FindWithTag("Dest").transform;
        throwable.GetComponent<BallCollectable>();
    }

    private void Update()
    {
        playerMovement.GetComponent<CharacterMovement>();


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
            throwable.ball.transform.position = theDest.position;
            throwable.ball.transform.parent = theDest;
            throwable.ball.GetComponent<Rigidbody>().isKinematic = true;
            isHolding = true;
        }

        else if (Input.GetMouseButtonDown(0) && isHolding)
        {           
            throwable.ball.transform.parent = null;
            isHolding = false;
            throwable.ball.GetComponent<Rigidbody>().isKinematic = false;
                      
            throwable.ball.GetComponent<Rigidbody>().AddForce(Camera.transform.forward * force * playerMovement.velocitySpeed / 2, ForceMode.Impulse);
            Debug.Log(playerMovement.velocity);
        }
    }
}
