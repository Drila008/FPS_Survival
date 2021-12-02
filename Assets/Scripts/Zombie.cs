using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int health;

    NavMeshAgent agent;
    public GameObject target;
    public GameObject manager;
    public bool attackCD;

    public AudioSource zombieAS;
    public AudioClip attack;
    public AudioClip breath;

    public float soundTimer = 0f;
    public float timer = 0f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        manager = GameObject.FindGameObjectWithTag("GameManager");
        health = manager.GetComponent<GameManager>().zombieHealth;
        agent.speed = manager.GetComponent<GameManager>().zombieSpeed;
        zombieAS = GetComponent<AudioSource>();

        soundTimer = Random.Range(3f, 12f);
        attackCD = false;


    }

    // Update is called once per frame
    void Update()
    {
        
        agent.destination = target.transform.position; //Move towards player
        animator.SetFloat("Speed", agent.velocity.magnitude); //Set animation according to speed (currently moves all the time)

        timer += Time.deltaTime;

        if(timer >= soundTimer) //Play a breathing sound to alert the player
        {
            PlaySound();
            timer = 0f;
        }

        if (Vector3.Distance(transform.position, target.transform.position) < 1.5f && !attackCD) //Attack the player when close enough
        {
            zombieAS.PlayOneShot(attack);
            animator.SetTrigger("Attack");
            attackCD = true;
            target.GetComponent<Player>().TakeDamage();
            StartCoroutine(AttackCooldown());
            Debug.Log("Sattuu");
        }
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
            
    }
    void PlaySound()
    {
        zombieAS.PlayOneShot(breath);
        soundTimer = Random.Range(5f, 12f);
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(2f);
        attackCD = false;
    }
}
