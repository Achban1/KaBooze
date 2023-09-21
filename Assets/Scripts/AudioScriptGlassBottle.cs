using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptGlassBottle : MonoBehaviour
{

    public AudioClip[] bottleBreakSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void GlassBreakSound()
    {
        int randomIndex = Random.Range(0, bottleBreakSound.Length);
        audioSource.clip = bottleBreakSound[randomIndex];
        audioSource.Play();
    }
}
