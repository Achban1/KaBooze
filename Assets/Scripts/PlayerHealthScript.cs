using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private GameObject _deathEffect, _hitEffect;
    private float _currentHealth;

    [SerializeField] private HealtbarScript _healthbar;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
    }

    void OnMouseDown()
    {
        _currentHealth -= 10;

        if (_currentHealth <= 0)
        {
            Instantiate(_deathEffect, transform.position,Quaternion.Euler(-90,0,0));
        }
        else
        {
            _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
            Instantiate(_hitEffect, transform.position, Quaternion.identity);
        }
    }
}