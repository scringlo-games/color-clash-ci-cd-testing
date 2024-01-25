using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public HealthHandler health;
    public Image healthIndicator;
    void OnEnable()
    {
        HealthHandler.currentHealth += HealthVisual;
    }
    void OnDisable()
    {
        HealthHandler.currentHealth -= HealthVisual;
    }
    void HealthVisual(int amount)
    {
        float fill = (float)amount/(float)health.maxHealth;
        Debug.Log($"health: {amount} maxHealth: {health.maxHealth} fill %: {fill}");
        healthIndicator.fillAmount = fill;
        // Debug.Log($"Max Width: {maxWidth}");
        // Debug.Log($"health increment amount{healthIncrement}");
        // Debug.Log($"X: {width},Y: {height}");
       
    }
}
