using UnityEngine;

public class Mesa : MonoBehaviour
{
    public bool clienteEnMesa = false;
    private Cliente clienteActual;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cliente"))
        {
            Debug.Log("Cliente ha llegado a la mesa");
            clienteEnMesa = true;

            // Obtener el componente Cliente del objeto Cliente que ha llegado a la mesa
            clienteActual = other.GetComponent<Cliente>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cliente"))
        {
            Debug.Log("Cliente ha dejado la mesa");
            clienteEnMesa = false;

            // Limpiar la referencia al cliente actual al salir
            clienteActual = null;
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        if (clienteEnMesa && clienteActual != null)
        {
            Plato_Class plato = other.GetComponent<Plato_Class>();

            // Verificar si el objeto en la mesa es un plato
            if (plato != null)
            {
                // Notificar al cliente que se ha entregado un plato, pasando el componente del plato
                clienteActual.PlatoEntregado(plato);
            }
        }
    }*/
}
