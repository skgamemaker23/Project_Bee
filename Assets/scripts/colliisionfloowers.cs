using UnityEngine;
//handles points and sparkle effect
public class Flowers : MonoBehaviour
{
    [Header("partclesettings")]
    public ParticleSystem particleSystem; //pollen 
    public float playTime = 1f; // seconds to play

    private float timeElapsed = 0f;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private bool playOnce = false;

    [Header("Collision Settings")]
    [SerializeField] private string targetTag = "flower1";
    [SerializeField] private float minCollisionForce = 0.00004f;

    private AudioSource audioSource;
    private bool hasPlayed = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particleSystem.Stop();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configure AudioSource
        audioSource.playOnAwake = false;
        audioSource.clip = collisionSound;
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.thisGameObject.CompareTag("flower1")) //the tall flowers 
        {
            AddPoints(20);
            if (timeElapsed < playTime)
            {
                particleSystem.Play();
                timeElapsed += Time.deltaTime;
            }
            else
            {
                // Stop the system after the set time
                particleSystem.Stop();
                timeElapsed = 0f; //reset
                gameObject.tag = "pollinated"; //sets the flower to "done'" so player can't keep getting points fromm the same flower 

            }
        }

        else if (collision.thisGameObject.CompareTag("flower2"))//shorter flowers
        {
            AddPoints(10);
            if (timeElapsed < playTime)
            {
                particleSystem.Play();
                timeElapsed += Time.deltaTime;
            }
            else
            {
                // Stop the system after the set time
                particleSystem.Stop();
                timeElapsed = 0f; //reset
            }
                gameObject.tag = "pollinated";


        }
        else if (collision.thisGameObject.CompareTag("sunflower"))
        {
            AddPoints(30);
            if (timeElapsed < playTime)
            {
                particleSystem.Play();
                timeElapsed += Time.deltaTime;
            }
            else
            {
                // Stop the system after the set time
                particleSystem.Stop();
                timeElapsed = 0f; //reset
            }
                gameObject.tag = "pollinated";

        }
        else { } // so the game doesnt have an aneurysm when the tags don't match
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

    }
    public void AddPoints(int points)
    {
        ScoreManager.score += points; // gloibal var score
    }
    public void ResetPlayState()
    {
        hasPlayed = false;
    }
}
