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
    private Transform camTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float hi = Input.GetAxis("Horizontal");
        float vi = Input.GetAxis("Vertical");

        // Left and Right, Forward and Backward Movement , x and z Axis...
        if (rb.velocity.magnitude < maxSpeed)
        {
            // rb.velocity += new Vector3(vi, 0, -hi) * acceleration * Time.deltaTime;
            //rb.velocity += new Vector3(
            //    vi * camTransform.forward.x,
            //    0,
            //    -hi * camTransform.right.x
            //    ) * acceleration * Time.deltaTime;

            // forward is a direction vector ....

            rb.velocity += camTransform.forward * vi * acceleration * Time.deltaTime;
            rb.velocity += camTransform.right * hi * acceleration * Time.deltaTime;


            // I need to specify some range for the `forward` and `right` vectors...
            // coz right now the velocity can be applied towards the ground or to the sky...
            // Maybe have a Vector of Directions that can be moved in.. and
            // set the current direction in the Update Method based on the most fitting / Matching
            // direction of the current camTransform...

            Debug.Log("cam forward");
            Debug.Log(camTransform.forward);
            Debug.Log(rb.velocity);

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
