using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePoolBottles : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] BottleBreak;
    public float Volume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BottleSoundFX()
    {
        int randomIndex = Random.Range(0, BottleBreak.Length);
        audioSource.clip = BottleBreak[randomIndex];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
