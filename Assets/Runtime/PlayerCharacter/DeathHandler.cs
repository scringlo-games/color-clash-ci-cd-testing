using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [field: SerializeField]
    public HealthHandler healthScript {get; private set;}
    public event Action OnKilled;
    void OnEnable()
    {  
        healthScript.OnHealthChanged += Kill;
    }
    void OnDisable()
    {
        healthScript.OnHealthChanged -= Kill;
        
    }
    //Checks if health is below or equal to zero, then invokes the 'OnKilled' event if the condition is met.
    void Kill(int health)
    {
        string thisName = this.name;
        Debug.Log($"Health: {health}");
        if (health <= 0)
        {
            OnKilled?.Invoke();
            Debug.Log($"{thisName} Killed");
        }
    }
    
    
}
