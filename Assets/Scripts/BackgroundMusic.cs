using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource; // Reference to the AudioSource component
    public AudioSource musicSource1; // Reference to the music clip

    void Start()
    {
        musicSource.Play(); // Play background music when the game starts
        musicSource1.Play(); // Assign the music clip to the AudioSource component
    }
}
