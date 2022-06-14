using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    public event EventHandler OnHealthChanged;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    
            public float GetHealthPercent() {
            return (float)currentHealth / maxHealth;
        }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if (OnHealthChanged != null) OnHealthChanged(this,EventArgs.Empty);

        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
