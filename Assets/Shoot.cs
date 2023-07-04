using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shootingPoint;

    
    
    public float bulletSpeed = 10;
    public float ShootDelay = 0.5f;
    // public float ShootDelaySecondary = 0.5f;

    void Start()
    {
        // get child component
        Debug.Assert(shootingPoint != null, "NO SHOOTING POINT SET !", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse CLick -> Call Shoot method in shoot.cs (pass normalised vector of direction) ->
    }

    bool shoot(Vector3 direction)
    {
        return true;
        // instantiate the Bullet Object.
    }
}
