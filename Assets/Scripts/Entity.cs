using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Entity : MonoBehaviour{
    public int Health;
    public int MaxHealth;
    public event EventHandler<DamageTakenEventArgs> OnDamageTaken;

    void Start(){
        Health = MaxHealth;
    }

    public void TakeDamage(int hurt){
        Health -= hurt;
        Debug.Log("Health is currenty: " + Health);

        if (Health <= 0){
            Die();
        }

        var eventArgs = new DamageTakenEventArgs{
            DamageTaken = hurt
        };
        OnDamageTaken?.Invoke(this,eventArgs);

    }

    public abstract void Die();


}
