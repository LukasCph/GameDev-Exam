using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour{

    private Entity entity;
    public Transform HealthBarSprite;
    
    public void Start(){
        entity = gameObject.GetComponentInParent<Entity>();

        entity.OnDamageTaken+=UpdateHealthbar;
        
    }

    private void UpdateHealthbar(object sender, DamageTakenEventArgs eventArgs){
        var HealthBarPercent = (float)entity.Health/entity.MaxHealth;
        HealthBarSprite.transform.localScale = new Vector3(HealthBarPercent,0.5f,0);
    }


}
