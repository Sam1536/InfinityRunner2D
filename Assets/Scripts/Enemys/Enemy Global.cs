using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlobal : MonoBehaviour
{
    public int health;
    public int damage;

    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            int dmg = collision.GetComponent<PlayerProjectile>().damage;
            collision.GetComponent<PlayerProjectile>().OnHit();
            ApplyDamage(dmg);
        }

      
    }
}
