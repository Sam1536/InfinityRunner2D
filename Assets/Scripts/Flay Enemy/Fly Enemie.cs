using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemie : EnemyGlobal
{
    private Player player;
    private Rigidbody2D rig;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        

        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }

   protected  override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.OnHit(damage);
            Debug.Log(player);

        }

        if (collision.CompareTag("Bullet"))
        {
            int dmg = collision.GetComponent<PlayerProjectile>().damage;
            collision.GetComponent<PlayerProjectile>().OnHit();
            ApplyDamage(dmg);
            Debug.Log("Acertou!!");
        }
    }


}
