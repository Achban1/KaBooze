using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionGlass : MonoBehaviour
{
    public PlayerHealthScript health;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.tag == "Player")
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
            health.PlayerDamage(6);
            
        }
        


    }
}
