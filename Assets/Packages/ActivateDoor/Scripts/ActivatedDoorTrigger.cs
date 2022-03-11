using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedDoorTrigger : MonoBehaviour
{
    public ActivatedDoor door;
    public Material buttonOff;
    public AudioSource button;

    private bool hitOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        door.GetComponent<ActivatedDoor>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && hitOnce == false)
        {
            door.isOpen = true;
            door.playSound = true;
            this.GetComponent<Renderer>().material = buttonOff;
            button.Play();
            hitOnce = true;
        }
    }

}
