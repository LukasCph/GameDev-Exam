using UnityEngine;
using System;
public class Enemy : Entity{

    public LayerMask player;
    public CircleCollider2D c_collider;
    public int dmg;

    public override void Die(){
        Destroy(gameObject);
    }


}
