using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionGlass : MonoBehaviour
{

    public AudioSourcePoolBottles audioSourcePoolBottles;
    public AudioSourcePoolExplosion audioSourcePoolExplosion;
    public PlayerHealthScript health;

    void Start()
    {
        audioSourcePoolExplosion = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSourcePoolExplosion>();
        audioSourcePoolExplosion.ExplosionSoundFX();
        Destroy(gameObject, 2);  
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
            health.PlayerDamage(6);
        }
    }
}
