using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Color collectibleColor;       // The color of the collectible
    public AudioClip correctSound;       // Sound for correct collection
    public AudioClip incorrectSound;     // Sound for incorrect collection
    private AudioSource audioSource;     // AudioSource reference for sound effects

    void Start()
    {
        // Randomly assign either red or black color to the collectible
        if (Random.value > 0.5f)
        {
            collectibleColor = Color.red;
        }
        else
        {
            collectibleColor = Color.black;
        }
        
        // Set the color of the collectible's material
        GetComponent<Renderer>().material.color = collectibleColor;

        // Ensure the collectible has an AudioSource component attached
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();  // Add AudioSource if not found
        }
    }


    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;  // Set the clip
            audioSource.Play();       // Play the sound
        }
    }
}
