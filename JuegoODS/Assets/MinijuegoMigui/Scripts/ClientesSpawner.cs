using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteSpawner : MonoBehaviour
{
    public GameObject clientePrefab;   // Prefab del cliente que quieres instanciar
    public List<Transform> mesas;      // Lista de mesas a las que pueden ir los clientes
    public LayerMask mesaLayer;        // LayerMask para detectar las mesas
    public float spawnInterval = 8f;   // Intervalo entre instancias de clientes
    public float moveSpeed = 5f;       // Velocidad de movimiento del cliente

    void Start()
    {
        // Llama a la función SpawnCliente cada cierto intervalo
        InvokeRepeating("SpawnCliente", 0f, spawnInterval);
    }

    void SpawnCliente()
    {
        // Calcula una posición aleatoria de la lista de mesas
        int randomIndex = Random.Range(0, mesas.Count);
        Transform randomMesa = mesas[randomIndex];

        // Instancia el prefab del cliente en la posición actual del Spawner
        GameObject clienteInstance = Instantiate(clientePrefab, transform.position, Quaternion.identity);

        // Mueve al cliente hacia la posición aleatoria de la mesa
        StartCoroutine(MoveClienteToMesa(clienteInstance, randomMesa));
    }

    IEnumerator MoveClienteToMesa(GameObject cliente, Transform mesa)
    {
        // Espera un frame antes de iniciar el movimiento
        yield return null;

        // Mientras el cliente no haya llegado a la mesa
        while (!DetectarColisionConMesa(cliente, mesa))
        {
            // Calcula la dirección y distancia al objetivo
            Vector3 direction = mesa.position - cliente.transform.position;
            float distance = direction.magnitude;

            // Normaliza la dirección y aplica el movimiento
            direction.Normalize();
            cliente.transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

            // Espera un frame antes de la siguiente iteración
            yield return null;
        }

        // El cliente ha llegado a la mesa
        Debug.Log("Cliente ha llegado a la mesa en " + mesa.name);

        // Espera 9 segundos antes de destruir el cliente y volver al punto de spawn
        yield return new WaitForSeconds(9f);

        // Destruye al cliente
        Destroy(cliente);
    }

    bool DetectarColisionConMesa(GameObject cliente, Transform mesa)
    {
        float distanciaMaximaColision = 0.4f;
        // Configura el rayo desde la posición actual del cliente hacia la mesa
        Ray ray = new Ray(cliente.transform.position, mesa.position - cliente.transform.position);
        RaycastHit hit;

        // Comprueba si el rayo colisiona con el collider de la mesa
        // Comprueba si el rayo colisiona con el collider de la mesa
        if (Physics.Raycast(ray, out hit, distanciaMaximaColision, mesaLayer))

        {
            // Verifica que el objeto golpeado sea la mesa
            if (hit.collider.CompareTag("Mesa"))
            {
                return true;
            }
        }

        return false;
    }
}
