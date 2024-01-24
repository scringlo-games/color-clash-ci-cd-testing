using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [field: SerializeField]
    public HealthHandler healthScript {get; private set;}
    public static event Action characterKilled;
    // Start is called before the first frame update
    void OnEnable()
    {  
        HealthHandler.currentHealth += Kill;
    }
    void OnDisable()
    {
        HealthHandler.currentHealth -= Kill;
        
    }
    void Kill(int health)
    {
        string thisName = this.name;
        Debug.Log($"Health: {health}");
        if (health <= 0)
        {
            characterKilled?.Invoke();
            Debug.Log($"{thisName} Killed");
        }
    }
    
    
}
