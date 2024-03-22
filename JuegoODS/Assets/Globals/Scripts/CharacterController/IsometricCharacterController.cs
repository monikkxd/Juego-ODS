using UnityEngine;

public class IsometricCharacterController : MonoBehaviour
{

    public float MoveSpeed = 5.0f;
    public float pickUpRadius = 2.0f; // Ajusta el valor según tu necesidad

    private Rigidbody _rb;
    private Vector3 _inputDirection;

    private bool isHoldingObject = false;
    private GameObject heldObject;

    private float angleVelocity;

    [SerializeField] private Animator _animator;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.IsPause)
            return;

        // Obtener la entrada del jugador ademas que compara si debe pillar los inputs del mouse o no
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento en el espacio isométrico
        _inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Si hay entrada, ajustar la rotación del personaje
        if (_inputDirection != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(_inputDirection.x, _inputDirection.z) * Mathf.Rad2Deg;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref angleVelocity, 0.1f);
            _animator.transform.rotation = Quaternion.Euler(0, targetAngle - 45, 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingObject)
            {
                // Si ya se sostiene un objeto, suéltalo
                DropObject();
            }
            else
            {
                // Si no se sostiene un objeto, intenta recoger uno
                TryPickUpObject();
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.IsPause)
            return;

        // Animaciones cutres, con mas tiempo cambio la estructura
        if (_inputDirection != Vector3.zero)
            _animator.SetBool("IsWalking", true);
        else
            _animator.SetBool("IsWalking", false);

        // Mover el personaje en la dirección calculada
        _rb.velocity = (Quaternion.Euler(0, 45, 0) * _inputDirection) * MoveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        /* if (other.gameObject.CompareTag("Collectibles") && !isHoldingObject)
         {
             isHoldingObject = true;
             heldObject = other.gameObject;
             heldObject.transform.SetParent(transform); // Haz que el objeto sea hijo del personaje
             heldObject.GetComponent<Collider>().enabled = false; // Desactiva el colisionador para evitar interacciones no deseadas
         }*/
    }

    private void DropObject()
    {
        if (isHoldingObject && heldObject != null)
        {
            isHoldingObject = false;
            heldObject.transform.SetParent(null); // Devuelve el objeto a su posición original en la jerarquía
            heldObject.GetComponent<Collider>().enabled = true; // Activa el colisionador nuevamente
            heldObject = null;
        }
    }

    private void TryPickUpObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickUpRadius);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("Collectibles"))
            {
                isHoldingObject = true;
                heldObject = col.gameObject;
                heldObject.transform.SetParent(transform);
                heldObject.GetComponent<Collider>().enabled = false;
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }

}


