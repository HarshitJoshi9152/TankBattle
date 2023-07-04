using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    // Todo: Add Tag and Set Stats 
    // should stats like speed, damange, range be a part of ObjectFiring or Bullet Object ..??
    void Start()
    {
        
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
