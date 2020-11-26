using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public float Volume = 0.5f;

    public AudioClip BlockDestroyed;
    public AudioClip BallBounce;

    public AudioSource AudioSource;
    public AudioSource BackgroundMusic;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        BackgroundMusic.Play();
    }

    public void PlayBlockDestroyedSound()
    {
        AudioSource.PlayOneShot(BlockDestroyed, Volume);
    }

    public void PlayBallBounceSound()
    {
        AudioSource.PlayOneShot(BallBounce, Volume);
    }
}
