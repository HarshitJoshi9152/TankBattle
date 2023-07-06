using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script attached to the Bullet Prefab !
public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Todo: Add Tag and Set Stats 
    // should stats like speed, damange, range be a part of ObjectFiring or Bullet Object ..??

    private string shotBy;
    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(float velocity)
    {
        Debug.Log("Bullet INIT !");
        rb.velocity = transform.forward * velocity;

        // shotBy = objectName;
        // We need to add 
        // shoot towards AIM
        // add Particle Effects at muzzle + hit location
        // Add force to the Object HIT !
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        // todo: Maybe we should do this in the Enemies Collision Box !
    }

    // to destroy Bullets when they do beyond the Threshold
    void OnTriggerEnter(Collider other) {
        
    }
}
