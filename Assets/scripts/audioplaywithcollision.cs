using UnityEngine;
//codde from amajet.com 

public class CollisionAudioPlayer : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private bool playOnce = false;

    [Header("Collision Settings")]
    [SerializeField] private string targetTag = "flower1";
    [SerializeField] private float minCollisionForce = 0.00004f;

    private AudioSource audioSource;
    private bool hasPlayed = false;

    private void Start()
    {
        // Add AudioSource component if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configure AudioSource
        audioSource.playOnAwake = false;
        audioSource.clip = collisionSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if we should play only once and have already played
        if (playOnce && hasPlayed)
            return;

        // Check if we collided with the target object
        if (collision.thisGameObject.CompareTag(targetTag))
        {
            // Check if collision force is strong enough
            if (collision.relativeVelocity.magnitude >= minCollisionForce)
            {
                audioSource.Play();
                hasPlayed = true;
            }
        }
        else { } // so tthe game doesn't lose it's marbles when tags don't match

    }
}

    // Method to reset the play state if needed
    