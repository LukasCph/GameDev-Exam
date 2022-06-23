using UnityEngine;
using System;
public class Enemy : Entity{

    public LayerMask player;
    public int dmg;
    GameObject PlayerPos;
    private Animator            m_animator;


    void Start () {
        m_animator = GetComponent<Animator>();
    }


    public override void Die(){
        //m_animator.SetTrigger("Die");
        Destroy(gameObject);
    }

    public void Update(){
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = PlayerPos.transform.position;
    }

}
