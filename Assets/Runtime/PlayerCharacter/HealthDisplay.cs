using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public HealthHandler health;
    public Image healthIndicator;
    private float maxWidth;
    private float width;
    private float height;
    private float healthIncrement;
    void Start()
    {
        //creats healthIncrement, which is a variable that breaks up the width of the health indicator into even segments.
        maxWidth = healthIndicator.rectTransform.rect.width;
        height = healthIndicator.rectTransform.rect.height;
        width = maxWidth;
        healthIncrement = maxWidth/health.maxHealth;
        //Debug.Log($"current health: {health.maxHealth}");
    }
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
        //sets the width of the health indicator transform to be healthIncrement * the amount of health that the player has left.
        width = amount * healthIncrement;
        // Debug.Log($"Max Width: {maxWidth}");
        // Debug.Log($"health increment amount{healthIncrement}");
        // Debug.Log($"X: {width},Y: {height}");
        healthIndicator.rectTransform.sizeDelta = new UnityEngine.Vector2(width, height);
    }
}
