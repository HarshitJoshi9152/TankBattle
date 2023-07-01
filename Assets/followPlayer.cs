using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Follow Settings")]
    public GameObject objectToFollow;
    public Vector3 offset;

    public float mouseSenstivity;

    private float yaw = 0f; // total rotation around the vertical axis
    private float pitch = 0f;// total rotation around the horizontal axis
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
        Cursor.visible = false;  // Hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        //
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        // Update yaw and pitch angles
        // yaw += mx;
        // pitch -= my;
        // pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Rotate the camera based on yaw and pitch
        // transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        transform.RotateAround(objectToFollow.transform.position, Vector3.up, mx * mouseSenstivity);
        transform.RotateAround(objectToFollow.transform.position, Vector3.forward, my * mouseSenstivity);


        
        // Space.Self vs Space.World


        // THE TRICK IS TO ... NOT CHANGE THE Z AND Y AXIS POS VALUES..
        transform.position = objectToFollow.transform.position + transform.forward  * offset.x;




        // NEW CODE ??


        /* If you want to use
         * Quaternion.LookRotation(direction);
         * You need to change the position on mx and my and then use LookRotation...
         */







        // we should not HARD set it .... I think we only need to reset the X axis each time...
//        transform.position = objectToFollow.transform.position + offset;

        // WAIT I THINK WE DONT NEED TO ROTATE IT !
        // WE NEED TO CHANGE THE LOCATION AND THEN ROTATE THE CAMERA TOO !!!

//        float mx = Input.GetAxis("Mouse X") * mouseSenstivity;
//        float my = Input.GetAxis("Mouse Y") * mouseSenstivity;

        /* FOUND A BETTER ALTERNATIVE QUANTERNION.LOOKROTATION
        // We need to rotate the Camera around the objectToFollow
        // basically we need to change the z and y axis hmmm...
        // But for that we need to rotate around y-axis (left and right) & z-axis (top and bottom)

        // left and right
        transform.RotateAround(objectToFollow.transform.position, new Vector3(0, 1, 0), mouseSenstivity * mx);
        // top and bottom
        transform.RotateAround(objectToFollow.transform.position, new Vector3(0, 0, 1), mouseSenstivity * my);

        */

        // But now i need to move the camera...


        // IT WORKS FOR LOOKING AT THE OBJECT !
        //        Vector3 direction = objectToFollow.transform.position - transform.position;
        //        transform.rotation = Quaternion.LookRotation(direction);

        // Unlock Mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
            Cursor.visible = true;  // Show the cursor
        }
    }


    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor when the application regains focus
            Cursor.visible = false;  // Hide the cursor
        }
    }
}
