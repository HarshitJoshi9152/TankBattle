using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // Start is called before the first frame update

    // [Header("Objects")]
    public GameObject ShootingPoint;
    public GameObject BulletPrefab;
    public ShootingProperties Props;

    // STATE
    private float timePassed = 0f;
    /*

    TankPrefab
        Shooting Script
        IN - Shooting Properties
        IN - Shooting Point
        IN - Bullet Prefab
        Contains ->
            void public shoot

        -- (Can I add the Shoot function to the Scriptable Object too ???)
        -- Would it save memory ..??
    */

    void Start()
    {
        // get child component
        Debug.Assert(ShootingPoint != null, "NO SHOOTING POINT SET !", this.gameObject);
        Debug.Assert(BulletPrefab != null, "NO BULLET_PREFAB SET !", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse CLick -> Call Shoot method in shoot.cs (pass normalised vector of direction) ->
    }

    public bool shoot(Vector3 direction)
    {
        // Rate of firing !
        if (Time.time > timePassed) timePassed = Time.time + 1f/Props.FireRate;
        else return false;

        GameObject bullet = Instantiate(BulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);

        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.Init(Props.BulletSpeed);
        
        // can i convert to bullet class ..??
        return true;
    }
}
