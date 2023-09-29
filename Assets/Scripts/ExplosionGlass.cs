using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionGlass : MonoBehaviour
{

    public AudioScriptPlay audioScriptPlay;


    public PlayerHealthScript health;

    void Start()

    {       
        audioScriptPlay = GameObject.FindGameObjectWithTag("Explosions").GetComponent<AudioScriptPlay>();
        audioScriptPlay.PlayAuido();
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
