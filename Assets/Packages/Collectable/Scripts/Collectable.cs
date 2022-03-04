using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    float collectedTime;
    float respawnTime;

    [SerializeField] protected bool collected = false;

    int rotate = 30;
  
    // Update is called once per frame
    protected void GetObjectComponents(Renderer renderer, Collider collider)
    {
        renderer.GetComponent<Renderer>();
        collider.GetComponent<Collider>();
    }

    /*protected void TimeToRespawn(Renderer renderer, Collider collider)
    {
        gameObject.transform.Rotate(Vector3.up * rotate * Time.deltaTime);

        if (collected)
        {
            float timeSinceCollected = Time.time - collectedTime;
            if (timeSinceCollected >= respawnTime)
            {
                renderer.enabled = true;
                collider.enabled = true;
            }
        }
    }*/

    protected void ObjectCollected(Collider other, Renderer renderer, Collider collider)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collected = true;
        }
    }
}
