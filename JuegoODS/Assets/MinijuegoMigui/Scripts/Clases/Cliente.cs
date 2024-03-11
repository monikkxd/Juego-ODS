using UnityEngine;

public class Cliente : MonoBehaviour
{
    private bool pedidoCompletado = false;

    // M�todo para llamar cuando el pedido est� completado
    void PedidoCompletado()
    {
        pedidoCompletado = true;
        Debug.Log("�Pedido completado por el cliente en la mesa!");
        // Agrega aqu� cualquier otra l�gica que necesites cuando el pedido se completa
    }

    // M�todo para ser llamado por la mesa cuando se ha dejado un plato
    public void PlatoEntregado()
    {
        // Verifica si el pedido ya ha sido completado para evitar duplicados
        if (!pedidoCompletado)
        {
            // Marca el pedido como completado
            PedidoCompletado();
        }
    }
}
