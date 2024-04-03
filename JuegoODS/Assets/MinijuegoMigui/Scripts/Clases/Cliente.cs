using UnityEngine;

public class Cliente : MonoBehaviour
{
    private string[] tiposDePlato = { "Plato1", "Plato2", "Plato3" }; // Tipos de platos disponibles
    public string pedido; // El pedido que realiza el cliente
    private bool pedidoCompletado = false;

    void Start()
    {
        // Generar un pedido aleatorio para el cliente
        pedido = tiposDePlato[Random.Range(0, tiposDePlato.Length)];

        Debug.Log("Cliente en la mesa. Pedido: " + pedido);
    }

    // Método para llamar cuando el pedido está completado
    void PedidoCompletado()
    {
        pedidoCompletado = true;
        Debug.Log("¡Pedido completado por el cliente en la mesa!");
        // Agrega aquí cualquier otra lógica que necesites cuando el pedido se completa
    }

    // Método para ser llamado por la mesa cuando se ha dejado un plato
    public void PlatoEntregado(Plato_Class plato)
    {
        // Verifica si el pedido ya ha sido completado para evitar duplicados
        if (!pedidoCompletado && plato != null)
        {
            // Realiza la lógica de verificación del pedido aquí
            if (pedido == "Plato1" && plato is Plato_1)
            {
                Debug.Log("Pedido de Plato1 completado");
                PedidoCompletado();
            }
            else if (pedido == "Plato2" && plato is Plato_2)
            {
                Debug.Log("Pedido de Plato2 completado");
                PedidoCompletado();
            }
            else if (pedido == "Plato3" && plato is Plato_3)
            {
                Debug.Log("Pedido de Plato3 completado");
                PedidoCompletado();
            }
            else
            {
                Debug.Log("Pedido incorrecto");
            }
        }
    }
}
