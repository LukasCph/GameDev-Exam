
using UnityEngine;

public class HealthBarScript : MonoBehaviour{

    private HealthSystem healthSystem;
    public void Setup(HealthSystem healthSystem) {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e){
        transform.Find("PBar").localScale = new Vector3(healthSystem.GetHealthPercent(),1,0);
    }
    private void Update () {
        transform.Find("PBar").localScale = new Vector3(healthSystem.GetHealthPercent(),1,0);
    }

}
