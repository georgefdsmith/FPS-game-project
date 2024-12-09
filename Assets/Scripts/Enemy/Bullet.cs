using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10); //need to add enemy health fml
        }
        if(hitTransform.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            hitTransform.GetComponent<Health>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
