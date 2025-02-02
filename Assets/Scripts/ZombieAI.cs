using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    public float attackRange = 2f;
    public int health = 3;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.SetDestination(player.position); // Start chasing immediately
    }

    void Update()
    {
        agent.SetDestination(player.position); // Keep chasing player

        // If close enough, trigger attack animation
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage the player (implement player health)
            Debug.Log("Player hit!");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<ZombieSpawner>().ZombieKilled();
        FindObjectOfType<ScoreManager>().AddScore();
        Destroy(gameObject);
    }
}

