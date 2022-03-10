using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorTrigger : MonoBehaviour
{
    public AutomaticDoor door;    

    private void Start()
    {
        door.GetComponent<AutomaticDoor>();       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            door.isOpen = true;
            door.playSound = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {        
            door.isOpen = false;
            door.playSound = true;
        }

    }
}
