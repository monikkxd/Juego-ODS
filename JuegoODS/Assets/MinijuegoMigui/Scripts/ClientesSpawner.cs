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

    private void Start()
    {
        // Llama a la funci�n SpawnCliente cada cierto intervalo
        InvokeRepeating("SpawnCliente", 0f, spawnInterval);
    }

    private void SpawnCliente()
    {
        // Calcula una posici�n aleatoria de la lista de mesas (asegur�ndote de que sea diferente a la �ltima)
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, mesas.Count);
        } while (mesas[randomIndex] == null);

        Transform mesa = mesas[randomIndex];

        // Instancia el prefab del cliente en la posici�n actual del Spawner
        GameObject clienteInstance = Instantiate(clientePrefab, transform.position, Quaternion.identity);

        // Mueve al cliente hacia la posici�n de la mesa de manera asincr�nica
        StartCoroutine(MoverClienteAMesa(clienteInstance, mesa));
    }

    private IEnumerator MoverClienteAMesa(GameObject cliente, Transform mesa)
    {
        // Espera un frame antes de iniciar el movimiento
        yield return null;

        // Mientras el cliente no haya llegado a la mesa
        while (!DetectarColisionConMesa(cliente, mesa))
        {
            // Calcula la direcci�n y distancia al objetivo
            Vector3 direction = mesa.position - cliente.transform.position;
            float distance = direction.magnitude;

            // Normaliza la direcci�n y aplica el movimiento
            direction.Normalize();
            cliente.transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

            // Espera un frame antes de la siguiente iteraci�n
            yield return null;
        }

        // El cliente ha llegado a la mesa
        Debug.Log("Cliente ha llegado a la mesa en " + mesa.name);

        // Realiza el pedido al llegar a la mesa
        cliente.GetComponent<Cliente>().RealizarPedido();
    }

    private bool DetectarColisionConMesa(GameObject cliente, Transform mesa)
    {
        float distanciaMaximaColision = 0.4f;
        // Configura el rayo desde la posici�n actual del cliente hacia la mesa
        Ray ray = new Ray(cliente.transform.position, mesa.position - cliente.transform.position);
        RaycastHit hit;

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
