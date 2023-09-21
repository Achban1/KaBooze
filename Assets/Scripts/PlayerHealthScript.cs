using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private GameObject _deathEffect, _hitEffect;
    public float _currentHealth;
    //Collected cash
    public float collectedCash = 0;
    


    [SerializeField] public HealthbarScript _healthbar;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
    } 
    
    public void PlayerDamage(int DamageDone)
    {
        _currentHealth -= DamageDone;
        _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
    }
    
    
}