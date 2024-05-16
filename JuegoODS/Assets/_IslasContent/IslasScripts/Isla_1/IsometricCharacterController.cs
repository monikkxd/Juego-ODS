using UnityEngine;

public class IsometricCharacterController : MonoBehaviour
{
    public float walkSpeed = 4f;
    public Animator animator; // Referencia al componente Animator

    private Vector3 forward, right;
    private float moveSpeed;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward = Vector3.Normalize(forward);

        // -45 grados desde el eje x del mundo
        right = Quaternion.Euler(new Vector3(0f, 90f, 0f)) * forward;

        // Velocidad inicial
        moveSpeed = walkSpeed;

        // Obtener el componente Animator adjunto al objeto
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Si se presiona alguna tecla de movimiento, mover y activar la animación
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            Move();

            // Activar la animación "CorrerPrincipal"
            animator.SetBool("isRunning", true);
        }
        else
        {
            // Si no hay entrada de movimiento, desactivar la animación
            animator.SetBool("isRunning", false);
        }
    }

    void Move()
    {
        // Movimiento horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 rightMovement = right * moveSpeed * horizontalInput;
        Vector3 upMovement = forward * moveSpeed * verticalInput;

        // Calcular dirección de movimiento
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        // Calcular nueva posición
        Vector3 newPosition = transform.position + rightMovement + upMovement;

        // Mover suavemente a la nueva posición
        transform.forward = heading;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    }
}
