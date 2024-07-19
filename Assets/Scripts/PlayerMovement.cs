using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    public bool right = false;
    public bool left = false;

    void Update()
    {
        // Check for 'D' key or right arrow key
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
        }
        else
        {
            right = false;
        }

        // Check for 'A' key or left arrow key
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }

    // "Fixed" Update is for physics
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (right)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (left)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
