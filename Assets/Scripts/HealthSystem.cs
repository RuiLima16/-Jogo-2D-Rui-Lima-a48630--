using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBarSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Heal(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            
            Debug.Log("Player has died!");
        }

        UpdateHealthBar();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
       
        float healthPercentage = (float)currentHealth / maxHealth;

        
        if (healthBarSlider != null)
        {
            healthBarSlider.value = healthPercentage;
        }
    }
}
