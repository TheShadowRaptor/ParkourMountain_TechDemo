using UnityEngine;

public class PickUpBall : MonoBehaviour
{
    //initilize destination
    private Transform theDest;

    //Sounds
    public AudioSource catchSound;

    //Gameobjects
    public GameObject player;
    public GameObject pickUpCheck;

    //pickUp checking
    public float pickUpDistance = 1f;
    public LayerMask pickUpMask;

    public bool canPickUp = false;
    public bool isHolding = false;

    //initilize BallCollectable script
    public BallCollectable ballCollectable;

    // Start is called before the first frame update
    void Start()
    {
        theDest = GameObject.FindWithTag("Dest").transform;
    }

    private void Update()
    {
        //Check if looking at ball
        RaycastHit hit;
        if (Physics.Raycast(pickUpCheck.transform.position, pickUpCheck.transform.TransformDirection(Vector3.forward), out hit, pickUpDistance, pickUpMask))
        {
            Debug.DrawRay(pickUpCheck.transform.position, pickUpCheck.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            canPickUp = true;
        }

        else
        {
            Debug.DrawRay(pickUpCheck.transform.position, pickUpCheck.transform.TransformDirection(Vector3.forward) * pickUpDistance, Color.green);
            canPickUp = false;
            
        }

        //Pick up ball
        if (Input.GetMouseButtonDown(0) && canPickUp == true)
        {
            catchSound.Play();
            ballCollectable.ball.transform.position = theDest.position;
            ballCollectable.ball.transform.parent = theDest;
            ballCollectable.ball.GetComponent<Rigidbody>().isKinematic = true;
            isHolding = true;
        }
    }
}
