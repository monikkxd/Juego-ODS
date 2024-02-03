using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadDescenso = 2f;
    public float velocidadAscenso = 2f;
    public GameObject objetoVacioRango;
    public float alturaObjetoVacioRango = 5f;

    private bool descenderActivado = false;
    private bool ascenderActivado = false;
    private bool permitirMovimientoHorizontal = true;
    private Transform objetoCogido; // Variable para mantener referencia al objeto cogido

    void Start()
    {
        objetoVacioRango.transform.position = new Vector3(transform.position.x, alturaObjetoVacioRango, transform.position.z);
    }

    void Update()
    {
        MoverGrua();

        if (Input.GetKeyDown(KeyCode.F))
        {
            DescenderObjeto();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AscenderObjeto();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SoltarObjeto();
        }

        if (descenderActivado)
        {
            DescenderObjeto();
        }

        if (ascenderActivado)
        {
            AscenderObjeto();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CogerObjeto();
        }
    }

    void MoverGrua()
    {
        if (permitirMovimientoHorizontal)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

            transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
        }
    }

    void DescenderObjeto()
    {
        RaycastHit hit;

        if (Physics.Raycast(objetoVacioRango.transform.position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Objeto_Grua"))
            {
                transform.Translate(Vector3.down * velocidadDescenso * Time.deltaTime);
                descenderActivado = true;
                permitirMovimientoHorizontal = false;
            }
            else
            {
                descenderActivado = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * velocidadDescenso * Time.deltaTime);
            descenderActivado = true;
            permitirMovimientoHorizontal = false;
        }
    }

    void AscenderObjeto()
    {
        // Verifica si ya ha alcanzado el punto de descenso antes de permitir el ascenso
        if (transform.position.y >= alturaObjetoVacioRango)
        {
            ascenderActivado = false;
            permitirMovimientoHorizontal = true; // Permite el movimiento horizontal despu�s del ascenso
            return;
        }

        transform.Translate(Vector3.up * velocidadAscenso * Time.deltaTime);
        ascenderActivado = true;
        permitirMovimientoHorizontal = false; // Bloquear el movimiento horizontal durante el ascenso
    }

    void CogerObjeto()
    {
        Collider[] colliders = Physics.OverlapSphere(objetoVacioRango.transform.position, objetoVacioRango.transform.localScale.x / 2);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Objeto_Grua"))
            {
                objetoCogido = collider.transform; // Almacenar la referencia al objeto cogido
                objetoCogido.parent = transform;
                objetoCogido.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void SoltarObjeto()
    {
        if (objetoCogido != null)
        {
            // Suelta el objeto, restablece su kinematic y qu�tale como hijo de la gr�a
            objetoCogido.parent = null;
            objetoCogido.GetComponent<Rigidbody>().isKinematic = false;
            objetoCogido = null; // Restablecer la referencia al objeto cogido
        }
    }
}
