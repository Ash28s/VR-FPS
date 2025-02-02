// using UnityEngine;
// using OculusSampleFramework;


// public class Gun : MonoBehaviour
// {
//     [Header("Gun Settings")]
//     public Transform firePoint; // Position where the bullets are fired
//     public GameObject bulletPrefab; // Prefab of the bullet
//     public float bulletSpeed = 50f; // Speed of the bullet

//     [Header("VR Controls")]
//     public OVRInput.Button shootButton = OVRInput.Button.PrimaryIndexTrigger; // Trigger button for shooting

//     [Header("Audio and Effects")]
//     public AudioSource shootingSound; // Optional: Sound effect for shooting
//     public ParticleSystem muzzleFlash; // Optional: Muzzle flash particle effect

//     void Update()
//     {
//         // Check if the shoot button is pressed
//         if (OVRInput.GetDown(shootButton))
//         {
//             Shoot();
//         }
//     }

//     void Shoot()
//     {
//         // Create the bullet
//         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

//         // Apply velocity to the bullet
//         Rigidbody rb = bullet.GetComponent<Rigidbody>();
//         if (rb != null)
//         {
//             rb.velocity = firePoint.forward * bulletSpeed;
//         }

//         // Play the shooting sound if assigned
//         if (shootingSound != null)
//         {
//             shootingSound.Play();
//         }

//         // Play muzzle flash effect if assigned
//         if (muzzleFlash != null)
//         {
//             muzzleFlash.Play();
//         }

//         // Destroy the bullet after a few seconds to optimize performance
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

    void Shoot()
    {
        // Create bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Apply velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        // Play shooting sound if assigned
        if (shootingSound != null)
        {
            shootingSound.Play();
        }

        // Play muzzle flash effect if assigned
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // Destroy bullet after 3 seconds to optimize performance
        Destroy(bullet, 3f);
    }
}
