using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    public float Health { get; protected set; }
    public bool IsAlive { get; protected set; }

    protected static float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        Health = 1f;
        IsAlive = true;
        maxHealth = Health;//maxHealth is the health at start
    }

    public void DecreaseHealth(float amount = .05f)
    {
        Health -= amount;

        if(Health <= 0)
        {
            IsAlive = false;
        }
    }

    public void IncreaseHealth(float amount = .05f)
    {
        Health += amount;

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

}
