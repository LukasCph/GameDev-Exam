using System;

public class HealthSystem {
    private int health;
    public event EventHandler OnHealthChanged;
    private int healthMax;
    public HealthSystem (int health) {
        this.health = health;
        health = healthMax;
        }
        public int GetHealth() {
            return health;
        }

        public float GetHealthPercent() {
            return (float)health / healthMax;
        }

        public void Damage(int damageAmount) {
            health -= damageAmount;
            if (health < 0) health = 0;
            if (OnHealthChanged != null) OnHealthChanged(this,EventArgs.Empty);
        }

        public void Heal(int healAmount){
            health += healAmount;
            if (health > healthMax) health = healthMax; 
            if (OnHealthChanged != null) OnHealthChanged(this,EventArgs.Empty);
        }
    }