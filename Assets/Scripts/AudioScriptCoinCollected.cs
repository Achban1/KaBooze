using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptCoinCollected : MonoBehaviour
{
    public AudioClip[] CoinCollectSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


    }


    public void CoinCollectSoundFX()
    {
        int randomIndex = Random.Range(0, CoinCollectSound.Length);
        audioSource.clip = CoinCollectSound[randomIndex];
        audioSource.PlayOneShot(audioSource.clip);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
