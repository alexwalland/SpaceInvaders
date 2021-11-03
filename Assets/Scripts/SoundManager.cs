using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public AudioClip alienFire;
    public AudioClip playerFire;
    public AudioClip Explosion;

    private AudioSource SFXAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
        else if (Instance != this)
            {
            Destroy(gameObject);
            }

        AudioSource Source = GetComponent<AudioSource>();
        SFXAudio = Source;
    }

    public void PlaySound (AudioClip sound)
    {
        SFXAudio.PlayOneShot(sound);
    }
}
