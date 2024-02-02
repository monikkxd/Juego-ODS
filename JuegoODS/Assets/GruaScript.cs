using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadDescenso = 2f;

    private bool descenderActivado = false;
    void Update()
    {
        MoverGrua();

        if (Input.GetKeyDown(KeyCode.F))
        {
            DescenderObjeto();
        }

        if (descenderActivado)
        {
            DescenderObjeto();
        }
    }


    void MoverGrua()
    {
        // Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el movimiento en el eje x y z
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

        // Aplicar el movimiento al objeto
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
    }
    void DescenderObjeto()
    {
        transform.Translate(Vector3.down * velocidadDescenso * Time.deltaTime);

        // Verificar si hay colisión con un objeto que tenga el tag deseado
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Objeto_Grua"))
            {
                descenderActivado = false; // Desactivar el descenso si se detecta el objeto con el tag deseado
            }
        }
    }
}
