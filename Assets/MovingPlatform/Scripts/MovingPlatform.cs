using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float minHeight;
    private float maxHeight;
    private float minWidth;
    private float maxWidth;

    private bool platformSwitch = true;
    public bool isVertical;

    public float travelHeight;
    public float travelWidth;
    public float speed;

    public GameObject player;

   
    // Start is called before the first frame update
    void Start()
    {
        minHeight = this.transform.position.y;
        maxHeight = minHeight + travelHeight;

        minWidth = this.transform.position.x;
        maxWidth = minWidth + travelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (platformSwitch)
        {
            if(isVertical == true)
            {
                this.transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (this.transform.position.y >= maxHeight)
                {
                    platformSwitch = false;
                }
            }

            else if(isVertical == false)
            {
                this.transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (this.transform.position.x >= maxWidth)
                {
                    platformSwitch = false;
                }
            }
           
        }

        if (platformSwitch == false)
        {
            if (isVertical == true)
            {
                this.transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (this.transform.position.y <= minHeight)
                {
                    platformSwitch = true;
                }
            }

            else if (isVertical == false)
            {
                this.transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (this.transform.position.x <= minWidth)
                {
                    platformSwitch = true;
                }
            }
        }

        Vector3 clampedPosition = this.transform.position;
        if (this.transform.position.y < minHeight) clampedPosition.y = minHeight;
        if (this.transform.position.y > maxHeight) clampedPosition.y = maxHeight;
        if (this.transform.position.x < minWidth) clampedPosition.x = minWidth;
        if (this.transform.position.x > maxWidth) clampedPosition.x = maxWidth;
        this.transform.position = clampedPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}
