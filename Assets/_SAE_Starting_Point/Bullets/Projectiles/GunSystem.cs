using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    [SerializeField] float rateOfFire = 1f;
    [SerializeField] private Rigidbody Projectile;
    private int ProjectileSpeed = 100;
    private float FireRate = 1;  // The number of bullets fired per second
    private float lastfired;      // The value of Time.time at the last firing moment

    public float GetRateOffFire()
    {
        return rateOfFire;
    }
    public void Fire()
    {
        //Instantiates a beam prefab infront of itself every 1 second
        if (Time.time - lastfired > FireRate / FireRate)
        {
            lastfired = Time.time;
            Rigidbody clone;
            clone = Instantiate(Projectile, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * ProjectileSpeed);
        }

    }
}