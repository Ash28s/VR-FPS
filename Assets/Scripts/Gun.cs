// using UnityEngine;
// using UnityEngine.InputSystem;

// public class Gun : MonoBehaviour
// {
//     [Header("Gun Settings")]
//     public Transform firePoint;
//     public GameObject bulletPrefab;
//     public float bulletSpeed = 50f;

//     [Header("Input Action")]
//     public InputActionProperty shootAction; // Reference to XR Controller Input

//     [Header("Audio and Effects")]
//     public AudioSource shootingSound;
//     public ParticleSystem muzzleFlash;

//     void Update()
//     {
//         // Check if the trigger button is pressed
//         if (shootAction.action.WasPressedThisFrame())
//         {
//             Shoot();
//         }
//     }

//     void Shoot()
//     {
//         // Create bullet
//         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
//         // Apply velocity
//         Rigidbody rb = bullet.GetComponent<Rigidbody>();
//         if (rb != null)
//         {
//             rb.velocity = firePoint.forward * bulletSpeed;
//         }

//         // Play shooting sound if assigned
//         if (shootingSound != null)
//         {
//             shootingSound.Play();
//         }

//         // Play muzzle flash effect if assigned
//         if (muzzleFlash != null)
//         {
//             muzzleFlash.Play();
//         }

//         // Destroy bullet after 3 seconds to optimize performance
//         Destroy(bullet, 3f);
//     }
// }

using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;

    [Header("Input Action")]
    public InputActionProperty shootAction; // Reference to XR Controller Input

    [Header("Audio and Effects")]
    public AudioSource shootingSound;
    public ParticleSystem muzzleFlash;

    void Update()
    {
        // Check if the trigger button is pressed
        if (shootAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    // void Shoot()
    // {
    //     // Debug line to visualize shooting direction
    //     Debug.DrawRay(firePoint.position, firePoint.forward * 10, Color.red, 2f);

    //     // Create bullet
    //     GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    //     // Apply velocity
    //     Rigidbody rb = bullet.GetComponent<Rigidbody>();
    //     if (rb != null)
    //     {
    //         rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // For accurate collision
    //         rb.velocity = firePoint.forward * bulletSpeed; // Bullet moves in the correct direction
    //     }

    //     // Play shooting sound if assigned
    //     if (shootingSound != null)
    //     {
    //         shootingSound.Play();
    //     }

    //     // Play muzzle flash effect if assigned
    //     if (muzzleFlash != null)
    //     {
    //         muzzleFlash.Play();
    //     }

    //     // Destroy bullet after 3 seconds
    //     Destroy(bullet, 3f);
    // }

    void Shoot()
{
    // Instantiate bullet at firePoint position and rotation
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    // Correct bullet rotation
    bullet.transform.forward = firePoint.forward;

    // Apply velocity
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.velocity = firePoint.forward * bulletSpeed;
    }

    // Play shooting effects
    shootingSound?.Play();
    muzzleFlash?.Play();

    // Destroy bullet after 3 seconds
    Destroy(bullet, 3f);
}

}
