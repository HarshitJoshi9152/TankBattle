using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    // I think Force should be applied by external/other objects... to better physics..
    // We should manually set the velocity
    // Or USE A DIFFERENT VECTOR FOR FORCE...


    public float acceleration;
    public float maxSpeed;


    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hi = Input.GetAxis("Horizontal");
        float vi = Input.GetAxis("Vertical");

        // Left and Right, Forward and Backward Movement , x and z Axis...
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.velocity += new Vector3(vi, 0, -hi) * acceleration * Time.deltaTime;


            // Top and Bottom (y axis)
            if (Input.GetKeyDown(KeyCode.Q))
            {
                rb.velocity += new Vector3(0, acceleration, 0);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                rb.velocity -= new Vector3(0, acceleration, 0);
            }
        }

        // Brake
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity.Set(0, 0, 0);
        }

        // print(rb.velocity);
    }
}
