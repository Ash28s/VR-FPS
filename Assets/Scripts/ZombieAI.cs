// using UnityEngine;
// using UnityEngine.AI;

// public class ZombieAI : MonoBehaviour
// {
//     public Transform player;
//     private NavMeshAgent agent;
//     private Animator animator;
//     public float attackRange = 2f; // Range within which the zombie attacks
//     public int health = 3; // Health of the zombie

//     void Start()
//     {
//         agent = GetComponent<NavMeshAgent>();
//         animator = GetComponent<Animator>();
//         agent.SetDestination(player.position); // Start chasing the player immediately
//     }

//     void Update()
//     {
//         agent.SetDestination(player.position); // Continuously chase the player

//         // Check if the zombie is close enough to attack
//         if (Vector3.Distance(transform.position, player.position) <= attackRange)
//         {
//             animator.SetTrigger("Attack");
//         }
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // Handle player damage here (implement player health)
//             Debug.Log("Player hit!");
//         }
//     }

//     // Call this method when the zombie takes damage
//     public void TakeDamage(int damage)
//     {
//         health -= damage; // Subtract damage from health
//         if (health <= 0)
//         {
//             Die(); // Call Die() when health is 0 or below
//         }
//     }

//     // Handle zombie death
//     void Die()
//     {
//         // Notify the spawner that a zombie was killed
//         FindObjectOfType<ZombieSpawner>().ZombieKilled();

//         // Add to the player's score
//         ScoreManager.Instance.AddScore();

//         // Destroy the zombie GameObject
//         Destroy(gameObject);
//     }
// }


using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    public float attackRange = 2f; // Range within which the zombie attacks
    public int health = 3; // Health of the zombie

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.SetDestination(player.position); // Start chasing the player immediately
    }

    void Update()
    {
        agent.SetDestination(player.position); // Continuously chase the player

        // Check if the zombie is close enough to attack
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Check if hit by a bullet
        {
            // Apply damage
            TakeDamage(1);

            // Destroy the bullet
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Zombie took {damage} damage. Remaining health: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
{
    // Disable the NavMeshAgent so the zombie stops moving
    agent.isStopped = true;
    
    // Play the death animation
    animator.SetTrigger("Die");
    
    // Remove the zombie from the spawner count
    FindObjectOfType<ZombieSpawner>().ZombieKilled();

    // Add score
    ScoreManager.Instance.AddScore();

    // Destroy the zombie after animation finishes
    Destroy(gameObject, 2f); // Adjust timing based on animation length
}

}
