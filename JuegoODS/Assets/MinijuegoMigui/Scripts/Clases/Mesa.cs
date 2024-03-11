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

        if (other.CompareTag("Plato"))
        {
            Debug.Log("Plato detectado");

            // Verificar si el cliente actual tiene un plato entregado
            if (clienteActual != null)
            {
                // Notificar al cliente que se ha entregado un plato
                clienteActual.PlatoEntregado();
            }
            else
            {
                Debug.Log("Cliente actual no encontrado al detectar el plato");
            }
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
}
