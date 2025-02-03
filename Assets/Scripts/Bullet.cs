using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            ZombieAI zombie = collision.gameObject.GetComponent<ZombieAI>();
            if (zombie != null)
            {
                zombie.TakeDamage(1); // Apply damage to the zombie
            }

            Destroy(gameObject); // Destroy the bullet
        }
    }
}
