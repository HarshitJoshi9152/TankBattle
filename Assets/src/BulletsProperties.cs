using UnityEngine;

[CreateAssetMenu(fileName = "BulletsProperties", menuName = "Tank Battle/BulletsProperties", order = 0)]
public class ShootingProperties : ScriptableObject
{
    public float BulletSpeed = 100;
    public float FireRate = 15;
    public float Damage = 10;
    // We will add another Shooting Properties Object for another gun

}