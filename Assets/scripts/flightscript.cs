using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(Rigidbody))]
public class Aflyscript : MonoBehaviour
{

    public AudioSource source;
    public AudioLoudnessDetection detector;

    private float moveSpeed = 20f;

    
    

    private Rigidbody rb;


    public float loudnessSensibility = 100;
    public float threshold = 0.1f;
    public float speed = 2;
    

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 



    }

    

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * speed * Time.deltaTime);

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    
    void FixedUpdate()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        transform.Translate(Vector3.up * loudness * moveSpeed * Time.deltaTime);



    }
}



