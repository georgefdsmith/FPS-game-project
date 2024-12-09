using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform gunBarrel;
    public GameObject shootEffect;

    public Muzzle muzzle;

    public void Shoot()
    {
        Transform gunbarrel = gunBarrel;

        // Create the bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, gunBarrel.rotation);

        bullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * 50;

        if (shootEffect != null)
        {
            GameObject effect = Instantiate(shootEffect, gunBarrel.position, gunBarrel.rotation);
        }

        if (muzzle != null)
        {
            muzzle.Effect();
        }
    }
}
