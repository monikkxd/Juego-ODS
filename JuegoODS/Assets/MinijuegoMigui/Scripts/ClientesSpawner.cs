using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Add this using directive for NavMesh

public class ClienteSpawner : MonoBehaviour
{
    public GameObject clientePrefab;   // Prefab del cliente que quieres instanciar
    public List<Transform> mesas;      // Lista de mesas a las que pueden ir los clientes
    public LayerMask mesaLayer;        // LayerMask para detectar las mesas
    public float spawnInterval = 8f;   // Intervalo entre instancias de clientes
    public float moveSpeed = 5f;       // Velocidad de movimiento del cliente

    private void Start()
    {
        // Llama a la funci�n SpawnCliente cada cierto intervalo
        InvokeRepeating("SpawnCliente", 0f, spawnInterval);
    }

    private void SpawnCliente()
    {
        if (clientePrefab == null)
        {
            Debug.LogError("clientePrefab is not assigned in the Unity editor.");
            return;
        }

        if (mesas == null || mesas.Count == 0)
        {
            Debug.LogError("mesas list is empty or not assigned in the Unity editor.");
            return;
        }

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, mesas.Count);
        } while (mesas[randomIndex] == null);

        Transform mesa = mesas[randomIndex];

        // Instancia el prefab del cliente en la posici�n actual del Spawner
        GameObject clienteInstance = Instantiate(clientePrefab, transform.position, Quaternion.identity);

        // Obtiene el componente NavMeshAgent del cliente
        NavMeshAgent agent = clienteInstance.GetComponent<NavMeshAgent>();

        // Configura el destino del cliente usando el componente NavMeshAgent
        agent.destination = mesa.position;

        // Activa el componente NavMeshAgent
        agent.enabled = true;

        // Mueve al cliente hacia la posici�n de la mesa de manera asincr�nica
        StartCoroutine(MoverClienteAMesa(clienteInstance, mesa));
    }

    private IEnumerator MoverClienteAMesa(GameObject cliente, Transform mesa)
    {
        // Espera a que el cliente llegue a la mesa
        while (!cliente.GetComponent<NavMeshAgent>().pathPending && cliente.GetComponent<NavMeshAgent>().remainingDistance > 0.5f)
        {
            yield return null;
        }

        // El cliente ha llegado a la mesa
        Debug.Log("Cliente ha llegado a la mesa en " + mesa.name);

        // Realiza el pedido al llegar a la mesa
        cliente.GetComponent<Cliente>().RealizarPedido();
    }
}