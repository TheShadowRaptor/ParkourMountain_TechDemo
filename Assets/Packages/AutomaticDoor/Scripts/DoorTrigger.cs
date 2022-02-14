using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;    

    private void Start()
    {
        door.GetComponent<Door>();       
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
