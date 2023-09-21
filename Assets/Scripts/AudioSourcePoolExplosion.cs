using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePoolExplosion : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] Explosions;
    public float Volume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ExplosionSoundFX()
    {
        int randomIndex = Random.Range(0, Explosions.Length);
        audioSource.clip = Explosions[randomIndex];
        audioSource.PlayOneShot(audioSource.clip);
    }
}