using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptPlayerDeathSound : MonoBehaviour
{
    public AudioClip[] DeathSounds;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        
    }


    public void PlayerDeathSoundFX()
    {
        int randomIndex = Random.Range(0, DeathSounds.Length);
        audioSource.clip = DeathSounds[randomIndex];
        audioSource.PlayOneShot(audioSource.clip);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
