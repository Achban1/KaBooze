using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSounds : MonoBehaviour
{
    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Play the first audio
        
    }

    public void CatSoundFX()
    {
        audioSource.clip = firstAudioClip;
        audioSource.Play();
       



        audioSource.clip = secondAudioClip;
            audioSource.loop = true;  
            audioSource.Play();
        
    }
}