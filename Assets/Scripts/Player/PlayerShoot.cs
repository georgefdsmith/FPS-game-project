using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform gunBarrel;
    [SerializeField] private float hitscanRange = 100f;
    [SerializeField] private LayerMask hitscanLayers;

    public Muzzle muzzle;

    public void Shoot()
    {
        Transform gunbarrel = gunBarrel;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, hitscanRange, hitscanLayers))
        {
            Debug.Log(hit.collider.gameObject.name);

            Health enemyHealth = hit.collider.GetComponent<Health>();
            DamageFlash enemyFlashEffect = hit.collider.GetComponent<DamageFlash>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10); 
            }

            if (enemyFlashEffect != null)
            {
                enemyFlashEffect.FlashColour();
            }
        }


        if (muzzle != null)
        {
            muzzle.Effect();
        }
    }
}
