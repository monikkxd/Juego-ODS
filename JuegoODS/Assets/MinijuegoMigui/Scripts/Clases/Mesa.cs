using UnityEngine;

public class Mesa : MonoBehaviour
{
    public bool clienteEnMesa = false;
    private Cliente clienteActual;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cliente"))
        {
            Debug.Log("Cliente ha llegado a la mesa");
            clienteEnMesa = true;
            clienteActual = other.GetComponent<Cliente>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cliente"))
        {
            Debug.Log("Cliente ha dejado la mesa");
            clienteEnMesa = false;
            clienteActual = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (clienteEnMesa && clienteActual != null && other.CompareTag("Plato"))
        {
            // Verificar el tipo de plato entregado
            if (other.TryGetComponent<Plato_1>(out Plato_1 plato1) && plato1 != null)
            {
                VerificarPedido("Plato1", other.gameObject);
            }
            else if (other.TryGetComponent<Plato_2>(out Plato_2 plato2) && plato2 != null)
            {
                VerificarPedido("Plato2", other.gameObject);
            }
            else if (other.TryGetComponent<Plato_3>(out Plato_3 plato3) && plato3 != null)
            {
                VerificarPedido("Plato3", other.gameObject);
            }
        }
    }

    private void VerificarPedido(string tipoPlatoEntregado, GameObject platoEntregado)
    {
        if (clienteActual.PedidoEsCorrecto(tipoPlatoEntregado))
        {
            clienteActual.PedidoCompletado();
            Debug.Log("¡Pedido completado correctamente!");
        }
        else
        {
            gameManager.RestarDinero();
            Debug.Log("¡Pedido incorrecto! El cliente no solicitó este tipo de plato.");
        }

        // Destruir el plato entregado
        Destroy(platoEntregado);
    }
}
