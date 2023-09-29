using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100;
    [SerializeField] private GameObject deathEffect, hitEffect;
    public float currentHealth;
    //Collected cash
    public float collectedCash = 0;
    


    [SerializeField] public HealthbarScript healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthbar.UpdateHealthbar(maxHealth, currentHealth);
    } 
    
    public void PlayerDamage(int DamageDone)
    {
        currentHealth -= DamageDone;
        healthbar.UpdateHealthbar(maxHealth, currentHealth);
    }
    
    
}