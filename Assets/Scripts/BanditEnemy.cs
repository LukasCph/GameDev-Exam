using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BanditEnemy : MonoBehaviour
{
    public Transform LightBandit;
    private float aggroRange = 15f;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {


        navMeshAgent = GetComponent<NavMeshAgent>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, LightBandit.position) < aggroRange){
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(LightBandit.position);
        } else {
            navMeshAgent.isStopped = true;
        }
        navMeshAgent.SetDestination(LightBandit.position);
    }
}
