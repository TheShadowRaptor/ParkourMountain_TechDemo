using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    float collectedTime;
    public float respawnTime;

    bool collected = false;

    int rotate = 30;

    public MeshRenderer renderer;
    public BoxCollider b_Collider;
    // Update is called once per frame
    public void Start()
    {
        renderer.GetComponent<MeshRenderer>();
        b_Collider.GetComponent<BoxCollider>();

        
    }

    public void Update()
    {
        gameObject.transform.Rotate(Vector3.up * rotate * Time.deltaTime);
        
        if (collected)
        {
            float timeSinceCollected = Time.time - collectedTime;
            if (timeSinceCollected >= respawnTime)
            {
                renderer.enabled = true;
                b_Collider.enabled = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collected = true;
            renderer.enabled = false;
            b_Collider.enabled = false;
            collectedTime = Time.time;
        }
    }
}
