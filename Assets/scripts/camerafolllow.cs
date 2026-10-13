using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target; // Object to follow
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Camera position relative to target
    public float followSpeed = 5f; // Smoothness

    public float mouseSensitivity = .4f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(mouseY, mouseX, 0);
      
    }
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("SmoothCameraFollow: No target assigned!");
            return;
        }

        // Desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move camera
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Optional: Look at target
        transform.LookAt(target);
    }
}
