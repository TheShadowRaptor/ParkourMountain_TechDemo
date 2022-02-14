using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed;

    private float minHeight;
    private float maxHeight;
    private float doorHeight;

    public bool isOpen = false;
    public bool playSound;

    public AudioSource doorSound;

    private void Start()
    {
        doorSound.GetComponent<AudioSource>();
        doorHeight = transform.localScale.y;
        minHeight = transform.position.y;
        maxHeight = minHeight + doorHeight * 2;
    }
    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (playSound)
            {
                doorSound.Play();
                if (doorSound.isPlaying)
                {
                    playSound = false;
                }
            }
        }

        else if (isOpen == false)
        {
            this.transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (playSound)
            {
                doorSound.PlayDelayed(0.1f);
                if (doorSound.isPlaying)
                {
                    playSound = false;
                }
            }
        }

        Vector3 clampedPosition = this.transform.position;
        if (this.transform.position.y < minHeight) clampedPosition.y = minHeight;
        if (this.transform.position.y > maxHeight) clampedPosition.y = maxHeight; 
        this.transform.position = clampedPosition;
    }
}
