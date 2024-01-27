using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{   [field:SerializeField]
    public HealthHandler health {get; private  set;}
    [SerializeField]
    private Image healthIndicator;
    void OnEnable()
    {
        health.OnHealthChanged += HealthVisual;
    }
    void OnDisable()
    {
        health.OnHealthChanged -= HealthVisual;
    }
    //divides the current health by max health to return a float value between 0 - 1. This value is then used to 
    //set the fill amount of the indicator image.
    void HealthVisual(int amount)
    {
        float fill = (float)amount/(float)health.maxHealth;
        Debug.Log($"health: {amount} maxHealth: {health.maxHealth} fill %: {fill}");
        healthIndicator.fillAmount = fill;
    }
}
