using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptBartender : MonoBehaviour
{
    public AudioClip[] BartenderStartSounds;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int randomIndex = Random.Range(0, BartenderStartSounds.Length);
        audioSource.clip = BartenderStartSounds[randomIndex];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
