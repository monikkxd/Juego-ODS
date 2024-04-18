using UnityEngine;

public class Cliente : MonoBehaviour
{
    private string[] tiposDePlato = { "Plato1", "Plato2", "Plato3" };
    public string pedido; // El pedido que realiza el cliente
    private bool pedidoCompletado = false;

    public GameObject pedido_1;
    public GameObject pedido_2;
    public GameObject pedido_3;

    private Vector3 arriba = new Vector3(0, 1, 0);
    private Vector3 posicionSpawn; // Posici�n de spawn del cliente

    void Start()
    {
        // Guardar la posici�n de spawn del cliente
        posicionSpawn = transform.position;

        // Generar un pedido aleatorio para el cliente
        pedido = tiposDePlato[Random.Range(0, tiposDePlato.Length)];

        Debug.Log("Cliente en la mesa. Pedido: " + pedido);

        GameObject pedidoObjeto = null;

        // Determinar qu� objeto de pedido instanciar seg�n el pedido del cliente
        if (pedido == "Plato1")
        {
            pedidoObjeto = Instantiate(pedido_1, transform.position + arriba, Quaternion.identity);
        }
        else if (pedido == "Plato2")
        {
            pedidoObjeto = Instantiate(pedido_2, transform.position + arriba, Quaternion.identity);
        }
        else if (pedido == "Plato3")
        {
            pedidoObjeto = Instantiate(pedido_3, transform.position + arriba, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Tipo de plato desconocido");
            return;
        }

        // Asignar el objeto de pedido como hijo del cliente
        if (pedidoObjeto != null)
        {
            pedidoObjeto.transform.parent = transform;
        }
    }

    // M�todo para llamar cuando el pedido est� completado
    public void PedidoCompletado()
    {
        pedidoCompletado = true;
        Debug.Log("�Pedido completado por el cliente en la mesa!");

        // Mover al cliente de vuelta a su posici�n de spawn
        VolverASpawn();
    }

    // M�todo para mover al cliente de vuelta a su posici�n de spawn
    private void VolverASpawn()
    {
        // Velocidad de movimiento hacia la posici�n de spawn (ajusta seg�n sea necesario)
        float velocidadMovimiento = 5f;

        // Calcula la direcci�n hacia la posici�n de spawn
        Vector3 direccion = (posicionSpawn - transform.position).normalized;

        // Calcula la distancia restante hasta la posici�n de spawn
        float distanciaRestante = Vector3.Distance(transform.position, posicionSpawn);

        // Si la distancia restante es mayor que una peque�a tolerancia, sigue movi�ndose
        if (distanciaRestante > 0.1f)
        {
            // Calcula la cantidad de movimiento para este frame
            float movimientoEsteFrame = velocidadMovimiento * Time.deltaTime;

            // Si la cantidad de movimiento es mayor que la distancia restante, ajusta para detenerse exactamente en la posici�n de spawn
            if (movimientoEsteFrame > distanciaRestante)
            {
                movimientoEsteFrame = distanciaRestante;
            }

            // Aplica el movimiento hacia la posici�n de spawn utilizando MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, posicionSpawn, movimientoEsteFrame);
        }
        else
        {
            // Si est� lo suficientemente cerca, establece la posici�n exacta de spawn
            transform.position = posicionSpawn;
        }
    }




    public void PlatoEntregado(Plato_Class plato)
    {
        // Verifica si el pedido ya ha sido completado para evitar duplicados
        if (!pedidoCompletado && plato != null)
        {
            // Realiza la l�gica de verificaci�n del pedido aqu�
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
