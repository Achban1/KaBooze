using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptPunchSound : MonoBehaviour
{

    public AudioClip[] PunchSounds;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PunchSound()
    {
        int randomIndex = Random.Range(0, PunchSounds.Length);
        audioSource.clip = PunchSounds[randomIndex];
        audioSource.Play();
    }
}
