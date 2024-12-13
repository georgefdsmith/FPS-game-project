using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health;

    [SerializeField]
    private Enemy enemy;


    [Header("Health")]
    public int maxHealth = 100;

    private DamageFlash damageFlash;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
        {
            enemy.Die();
        }
    }

    public void TakeDamage(float damage)
    {
        if (health != 0)
        {
            health -= damage;
        }

        Debug.Log($"Enemy Took: {damage} Damage, and is now at: {health} Health.");
    }

}
