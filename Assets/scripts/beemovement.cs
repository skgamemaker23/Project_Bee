using UnityEngine;

//code from Valem Tutorials on YT (the audio portion) 
//basic movement from unity discussions and trial and error 
public class BeeController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 15f;
    public Rigidbody rb;

    [Header("Mouse Look")]
    public float mouseSensitivity = 120f;
    public Transform cameraTransform;
    private float pitch = 0f;

    [Header("Audio")]
    public AudioSource source;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb.freezeRotation = true; // Prevent physics rotation
    }

    void Update()
    {
        HandleMouseLook();
        
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleFlying();
    }

    void HandleMouseLook()
    {
        //gets mouse input and multiplies it so it doesn't clip like crazy 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Horizontal rotation (player)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (camera)
        pitch -= mouseY; 
        pitch = Mathf.Clamp(pitch, -35f, 50f); // clamp makes sure you can't go 360 top to bottom 
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void HandleMovement()
    {
        // accepts arrow keys/WASD/controller 
        float x = Input.GetAxisRaw("Horizontal"); 
        float z = Input.GetAxisRaw("Vertical");


        //create movement values using input 
        Vector3 moveDir = (transform.forward * z + transform.right * x).normalized;
        Vector3 targetPos = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;

        ////actually move lol 
        rb.MovePosition(targetPos);
    }

    void HandleFlying()
    {
        //grabs mic input using detector 
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        //makes sure there's enough to actually move
        if (loudness < threshold)
            loudness = 0;

        //move lol 
        rb.AddForce(Vector3.up * loudness * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);

    }
}