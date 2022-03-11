using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject spawn;
    public GameObject CheckpointSpawn;
    public AudioSource checkpointSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawn.transform.position = CheckpointSpawn.transform.position;
            this.gameObject.SetActive(false);
            checkpointSound.Play();
        }
    }
}
