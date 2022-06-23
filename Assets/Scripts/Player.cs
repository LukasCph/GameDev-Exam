using UnityEngine;
using System.Collections;

public class Player : Entity {

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 8f;
    float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public SpriteRenderer sprite;

    public Vector2 speed = new Vector2(50,50);

    private Animator            m_animator;
    private BoxCollider2D       box_collider;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        // -- Handle input and movement --
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        m_body2d.velocity = new Vector2(inputX * 0, 0);
        m_body2d.velocity = new Vector2(inputY * 0, 0);

        Vector3 movement = new Vector3((speed.x/10) * inputX, (speed.y/10)*inputY,0);
        movement *= Time.deltaTime;

        transform.Translate(movement);

        // -- Handle Animations --
        //Death
        if (Health <= 0) {
                m_animator.SetTrigger("Death");
        }

        //Attack
        else if (Input.GetKeyDown("e")){
           if(Time.time >= nextAttackTime) {
                    Attack();
                    nextAttackTime = Time.time + 1f/attackRate;
            } 
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("c"))
            m_combatIdle = !m_combatIdle;

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);
        else if (Mathf.Abs(inputY) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }

    public void Attack(){
        m_animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() {

        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    
    public void OnCollisionEnter2D(Collision2D col){
        var enemy = col.gameObject.GetComponent<Enemy>();

        if (enemy != null){
            TakeDamage(enemy.dmg);
            m_animator.SetTrigger("Hurt");
        }
        Debug.Log("We have a collision");
    }

    public override void Die(){
        Destroy(gameObject);
    }

}