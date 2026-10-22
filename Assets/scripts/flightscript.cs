using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

[RequireComponent(typeof(Rigidbody))]
public class Aflyscript : MonoBehaviour
{
    [SerializeField] private float _CameraSensitivity = 1;

    public AudioSource source;
    public AudioLoudnessDetection detector;

    private float moveSpeed = 20f;

    
    

    private Rigidbody rb;


    public float loudnessSensibility = 100;
    public float threshold = 0.1f;
    public float speed = 2;
    

 
   
    private float customgravity = 9f;
    private Vector2 _LookRot = new Vector2(90, 0);

            
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
       



    }

    

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal") * speed;
        float y = Input.GetAxisRaw("Vertical") * speed;

        Vector3 move = transform.right * x + transform.forward * y;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        _LookRot.x += Input.GetAxis("Mouse X") * _CameraSensitivity;
        _LookRot.y += Input.GetAxis("Mouse Y") * _CameraSensitivity;
        _LookRot.y = Mathf.Clamp(_LookRot.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(_LookRot.x, Vector3.up);
        transform.localRotation = Quaternion.AngleAxis(_LookRot.y, Vector3.left);
        transform.localRotation = Quaternion.AngleAxis(_LookRot.y, Vector3.left);

    }

    
    void FixedUpdate()
    {

        rb.AddForce(new Vector3(0, -2.0f, 0) * rb.mass * customgravity, ForceMode.Acceleration);

        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        rb.AddForce(Vector3.up * loudness * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);



    }



   
}



