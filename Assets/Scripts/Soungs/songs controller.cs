using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Songscontroller : MonoBehaviour
{
    public AudioClip AudioJump;
    public AudioClip AudioShoot;
    public AudioClip AudioExplosion;
    public AudioClip AudioBMG;

    private AudioSource audioSoucer;


    public static Songscontroller song;

    // Start is called before the first frame update
    void Start()
    {
        song = this;

        audioSoucer = GetComponent<AudioSource>();

    }

    public void PlayerMusic(AudioClip clip)
    {
        audioSoucer.PlayOneShot(clip);
    }
}
