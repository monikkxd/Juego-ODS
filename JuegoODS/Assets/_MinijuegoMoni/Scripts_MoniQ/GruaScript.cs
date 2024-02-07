using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadDescenso = 2f;
    public float velocidadAscenso = 2f;
    public GameObject grabPoint;
    public float alturaGrabPoint = 5f;

    private bool descenderActivado = false;
    private bool ascenderActivado = false;
    private bool permitirMovimientoHorizontal = true;
    private Transform objetoCogido;

    public float velocidadRotacion = 30f;
    private bool rotacionActiva = false;
    private float anguloTotal = 0f;
    private float anguloObjetivo = 90f;

    private float tamanoCasilla = 1;

    private bool permitirMovimientoHorizontal_ = true;
    private float tiempoEspera = 0.5f;
    private float tiempoUltimoMovimiento = 0f;

    void Start()
    {
        grabPoint.transform.position = new Vector3(transform.position.x, alturaGrabPoint, transform.position.z);
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

        if (Input.GetKeyDown(KeyCode.G) && !rotacionActiva)
        {
            rotacionActiva = true;
        }

        if (rotacionActiva)
        {
            RotarObjetoCogidoEnY();
        }

        MoverGrua();
    }

    void MoverGrua()
    {
        if (permitirMovimientoHorizontal)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 direccionMovimiento = new Vector3(
                Mathf.Abs(movimientoHorizontal) > Mathf.Abs(movimientoVertical) ? movimientoHorizontal : 0f,
                0f,
                Mathf.Abs(movimientoVertical) > Mathf.Abs(movimientoHorizontal) ? movimientoVertical : 0f
            ).normalized;

            float tiempoActual = Time.time;

            if (tiempoActual - tiempoUltimoMovimiento >= tiempoEspera)
            {
                Vector3 nuevaPosicion = CalcularNuevaPosicion(transform.position, direccionMovimiento);

                if (EstaEnCasilla(nuevaPosicion))
                {
                    transform.position = nuevaPosicion;
                    tiempoUltimoMovimiento = tiempoActual;
                }
            }
        }
    }

    Vector3 CalcularNuevaPosicion(Vector3 posicionActual, Vector3 direccionMovimiento)
    {
        Vector3 posicionCasilla = new Vector3(
            Mathf.Round(posicionActual.x / tamanoCasilla) * tamanoCasilla,
            posicionActual.y,
            Mathf.Round(posicionActual.z / tamanoCasilla) * tamanoCasilla
        );

        Vector3 nuevaPosicion = posicionCasilla + direccionMovimiento * tamanoCasilla;

        return nuevaPosicion;
    }

    bool EstaEnCasilla(Vector3 posicion)
    {
        Casillas divisor = FindObjectOfType<Casillas>();

        Renderer renderer = divisor.GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;

        if (posicion.x >= bounds.min.x && posicion.x <= bounds.max.x &&
            posicion.z >= bounds.min.z && posicion.z <= bounds.max.z)
        {
            return true;
        }

        return false;
    }

    void DescenderObjeto()
    {
        RaycastHit hit;

        if (Physics.Raycast(grabPoint.transform.position, Vector3.down, out hit))
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
        if (transform.position.y >= alturaGrabPoint)
        {
            ascenderActivado = false;
            permitirMovimientoHorizontal = true;
            return;
        }

        transform.Translate(Vector3.up * velocidadAscenso * Time.deltaTime);
        ascenderActivado = true;
        permitirMovimientoHorizontal = false;
    }

    void CogerObjeto()
    {
        Collider[] colliders = Physics.OverlapSphere(grabPoint.transform.position, grabPoint.transform.localScale.x / 2);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Objeto_Grua"))
            {
                objetoCogido = collider.transform;
                objetoCogido.parent = transform;
                objetoCogido.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void SoltarObjeto()
    {
        if (objetoCogido != null)
        {
            objetoCogido.parent = null;
            objetoCogido.GetComponent<Rigidbody>().isKinematic = false;
            objetoCogido = null;
        }
    }

    void RotarObjetoCogidoEnY()
    {
        if (objetoCogido != null)
        {
            float pasoRotacion = velocidadRotacion * Time.deltaTime;

            if (anguloTotal + pasoRotacion >= anguloObjetivo)
            {
                pasoRotacion = anguloObjetivo - anguloTotal;
                anguloTotal = 0f;
                rotacionActiva = false;
            }

            objetoCogido.Rotate(Vector3.up, pasoRotacion);
            anguloTotal += pasoRotacion;
        }
    }
}
