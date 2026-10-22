using UnityEngine;

public class BeeController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 15f;
    public Rigidbody rb;

    [Header("Mouse Look")]
    public float mouseSensitivity = 120f;
    public Transform cameraTransform;
    private float pitch = 0f;

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
        HandleFlying();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Horizontal rotation (player)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (camera)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -35f, 50f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = (transform.forward * z + transform.right * x).normalized;
        Vector3 targetPos = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPos);
    }

    void HandleFlying()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        
        rb.AddForce(Vector3.up * loudness * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);

    }
}