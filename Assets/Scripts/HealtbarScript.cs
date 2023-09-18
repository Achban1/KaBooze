using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtbarScript : MonoBehaviour
{
    [SerializeField] private Image _Healthbar;

    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        _Healthbar.fillAmount = currentHealth / maxHealth;
    }
}
