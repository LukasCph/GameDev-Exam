
using UnityEngine;

public class GameHandler : MonoBehaviour
{
public Transform pfHealthBar;

   
    void Start(){

        HealthSystem healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 5), Quaternion.identity);
        
        HealthBarScript healthBar = healthBarTransform.GetComponent<HealthBarScript>();

        healthBar.Setup(healthSystem);
        Debug.Log("Health: "+healthSystem.GetHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
