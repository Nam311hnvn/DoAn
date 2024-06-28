using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    Damageable damageable;

    public Slider healthSlider;
    public TMP_Text healthBarText;


    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player == null)
        {
            Debug.Log("Make sure it has tag 'Player'");
        }

        damageable = player.GetComponent<Damageable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalculatePercent(damageable.Health,damageable.MaxHealth);
        healthBarText.text = "HP" + damageable.Health + "/" +damageable.MaxHealth;
    }

    private void OnEnable()
    {
        damageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        damageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculatePercent(newHealth,maxHealth);
        healthBarText.text = "HP" + newHealth + "/" + maxHealth;
    }

    private float CalculatePercent(float currentHealth,float maxHealth)
    {
        return currentHealth/maxHealth;
    }

    
}
