 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header ("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip respawn;
    public AudioClip portal;
    public AudioClip sectionComplete;
    public AudioClip jumpPad;
    public AudioClip fullHP;
    public AudioClip fullHunger;
    public AudioClip collectFood;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
