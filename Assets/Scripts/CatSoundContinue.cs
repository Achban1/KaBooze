using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSoundContinue : MonoBehaviour
{
    public AudioClip CatWakeUp;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void CatContinueFX()
    {
        audioSource.Play();
    }
}
