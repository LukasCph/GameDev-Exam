
using UnityEngine;

public class EnemyBarScript : MonoBehaviour{

    private Enemy enemy;
    public void Setup(Enemy enemy) {
        this.enemy = enemy;

        enemy.OnHealthChanged += Enemy_OnHealthChanged;
    }

    private void Enemy_OnHealthChanged(object sender, System.EventArgs e){
        transform.Find("EBar").localScale = new Vector3(enemy.GetHealthPercent(),1,0);
    }
    private void Update () {
        transform.Find("EBar").localScale = new Vector3(enemy.GetHealthPercent(),1,0);
    }

}
