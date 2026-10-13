using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(Rigidbody))]
public class AuddioCubeMic : MonoBehaviour
{

    public AudioSource source;
    public AudioLoudnessDetection detector;


    private Rigidbody rb;
    private Vector2 velocity;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
      
        rb.constraints = RigidbodyConstraints.FreezeRotation;


    }



    void Update()
    {

    }

    void FixedUpdate()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        transform.Translate(Vector2.up * loudness * Time.deltaTime);


    }
}


