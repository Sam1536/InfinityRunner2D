using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    
    Rigidbody2D rig;
    public float speed;
    public int damage;

    public GameObject explosionPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rig.velocity = Vector2.right * speed;
    }

    public void OnHit()
    {
        GameObject e = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(e, 1f);
        Destroy(gameObject);
        Songscontroller.song.PlayerMusic(Songscontroller.song.AudioExplosion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            OnHit();
            
        }
    }

}
