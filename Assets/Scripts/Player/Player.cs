using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float JumpForce;
    public Animator anim;
    private bool isJump;

    public int health;
    public Text life;

    public GameObject bulletPrefab;
    public Transform bulletPoint;

   


    // Start is called before the first frame update
    void Start()
    {
       
        rig = GetComponent<Rigidbody2D>();
      
       
    }

 
    private void FixedUpdate() //ele é chamado pela fisica da unity
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }


    // Update is called once per frame
    void Update()// ele é chamado frame  
    {
        life.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)//isJump é igual a isJump == false
        {
            OnJump();
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            OnShoot();
        }
    }

    public void OnShoot()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        Songscontroller.song.PlayerMusic(Songscontroller.song.AudioShoot);
    } 
   
    public void OnJump()
    {
        if (!isJump)//isJump é igual a isJump == false
        {
            rig.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            isJump = true;
            Songscontroller.song.PlayerMusic(Songscontroller.song.AudioJump);// chama para produzir o audio
        }
    }


    public void OnHit(int dmg)
    {
        
        health  -= dmg; 


        if ( health <= 0)
        {
            GameControllerUI.instance.ShowGameOver();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.gameObject.layer == 6)
        {
            anim.SetBool("jump", false);
            isJump = false;
        }
    }
}
