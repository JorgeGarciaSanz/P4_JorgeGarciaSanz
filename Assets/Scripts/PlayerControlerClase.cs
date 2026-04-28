using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControlerClase : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Mouse")]
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private float maxPitch = 85.0f;

    [Header("Salto")]
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float groundCheckDistance = 1.1f;

    private Rigidbody m_Rigidbody;
    private float pitch = 0f;
    private bool grounded = false;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        // Recomendado para FPS: que no se tumbe con físicas
        m_Rigidbody.freezeRotation = true;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Yaw en el jugador (giro horizontal)
        transform.Rotate(0f, mouseX * rotationSpeed, 0f);

        // Pitch en la cámara (giro vertical con clamp)
        pitch -= mouseY * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Ground check simple (raycast hacia abajo)
        grounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Vector3 v = m_Rigidbody.linearVelocity; 
            v.y = 0f;
            m_Rigidbody.linearVelocity = v;

            m_Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Movimiento relativo a donde mira el player
        Vector3 moveDir = (transform.right * h + transform.forward * v).normalized;

        Vector3 velocity = moveDir * moveSpeed;
        velocity.y = m_Rigidbody.linearVelocity.y;
        m_Rigidbody.linearVelocity = velocity;
    }
}
