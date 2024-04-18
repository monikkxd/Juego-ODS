using UnityEngine;

public class Cliente : MonoBehaviour
{
    private string[] tiposDePlato = { "Plato1", "Plato2", "Plato3" };
    private bool pedidoCompletado = false;
    private Vector3 posicionSpawn; // Posición de spawn del cliente
    public Transform mesaAsignada; // Mesa a la que debe dirigirse el cliente

    public GameObject pedido_1; // Objeto a instanciar para el pedido Plato1
    public GameObject pedido_2; // Objeto a instanciar para el pedido Plato2
    public GameObject pedido_3; // Objeto a instanciar para el pedido Plato3

    private void Start()
    {
        // Guardar la posición de spawn del cliente
        posicionSpawn = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mesa") && !pedidoCompletado)
        {
            // Realizar el pedido al llegar a la mesa
            RealizarPedido();
        }
    }

    public void RealizarPedido()
    {
        // Determinar qué objeto de pedido instanciar según los platos disponibles en la escena
        string pedido = ObtenerPedidoBasadoEnPlatosDisponibles();
        if (pedido == null)
        {
            Debug.LogError("No hay platos disponibles en la escena.");
            return;
        }

        GameObject pedidoObjeto = null;
        switch (pedido)
        {
            case "Plato1":
                pedidoObjeto = Instantiate(pedido_1, transform.position + Vector3.up, Quaternion.identity);
                break;
            case "Plato2":
                pedidoObjeto = Instantiate(pedido_2, transform.position + Vector3.up, Quaternion.identity);
                break;
            case "Plato3":
                pedidoObjeto = Instantiate(pedido_3, transform.position + Vector3.up, Quaternion.identity);
                break;
            default:
                Debug.LogError("Tipo de plato desconocido");
                return;
        }

        // Asignar el objeto de pedido como hijo del cliente y ajustar su posición relativa
        if (pedidoObjeto != null)
        {
            pedidoObjeto.transform.parent = transform;
            pedidoObjeto.transform.localPosition = Vector3.up; // Posición relativa 1 unidad sobre el cliente en el eje Y
        }
    }

    private string ObtenerPedidoBasadoEnPlatosDisponibles()
    {
        // Detectar todos los platos disponibles en la escena
        Plato_1[] platosTipo1 = FindObjectsOfType<Plato_1>();
        Plato_2[] platosTipo2 = FindObjectsOfType<Plato_2>();
        Plato_3[] platosTipo3 = FindObjectsOfType<Plato_3>();

        // Determinar los tipos de platos disponibles
        bool hayPlato1 = platosTipo1.Length > 0;
        bool hayPlato2 = platosTipo2.Length > 0;
        bool hayPlato3 = platosTipo3.Length > 0;

        // Determinar el pedido en función de los platos disponibles
        if (hayPlato1 && hayPlato2 && hayPlato3)
        {
            // Todos los tipos de platos disponibles
            return tiposDePlato[Random.Range(0, tiposDePlato.Length)];
        }
        else if (hayPlato1 && hayPlato2)
        {
            // Plato1 y Plato2 disponibles
            return Random.Range(0, 2) == 0 ? "Plato1" : "Plato2";
        }
        else if (hayPlato1 && hayPlato3)
        {
            // Plato1 y Plato3 disponibles
            return Random.Range(0, 2) == 0 ? "Plato1" : "Plato3";
        }
        else if (hayPlato2 && hayPlato3)
        {
            // Plato2 y Plato3 disponibles
            return Random.Range(0, 2) == 0 ? "Plato2" : "Plato3";
        }
        else if (hayPlato1)
        {
            // Solo Plato1 disponible
            return "Plato1";
        }
        else if (hayPlato2)
        {
            // Solo Plato2 disponible
            return "Plato2";
        }
        else if (hayPlato3)
        {
            // Solo Plato3 disponible
            return "Plato3";
        }

        // No hay platos disponibles
        return null;
    }

    public void PedidoCompletado()
    {
        pedidoCompletado = true;
        Debug.Log("¡Pedido completado por el cliente en la mesa!");

        // Mover al cliente de vuelta a su posición de spawn
        VolverASpawn();
    }

    private void VolverASpawn()
    {
        // Implementa el código para mover al cliente de vuelta a la posición de spawn
        // Puedes utilizar el mismo método VolverASpawn que se discutió anteriormente
    }
}
