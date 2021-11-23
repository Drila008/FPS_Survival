using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
