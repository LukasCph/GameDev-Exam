using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{

    public LayerMask player;
    public CircleCollider2D c_collider;
    public int maxHealth;
    public event EventHandler OnHealthChanged;
    int currentHealth;
    public int dmg;
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    void update () {
        DealDamage(dmg);
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

    public void DealDamage(int dmg){
        Vector2 pos = GetComponent<Transform>().position;
        float range = c_collider.radius + 1f;
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(pos, range, player);

        foreach(Collider2D player in playerHit)
        {
            player.GetComponent<Player>().Hurt(dmg);
            Debug.Log("We hit "+player.name+ "and inflicted " + dmg +"damage" );
        }
    }

}
