using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Cliente : MonoBehaviour
{
    private string tipoPedido;
    private bool pedidoCompletado = false;
    private Vector3 posicionSpawn;
    public Transform mesaAsignada;
    public float velocidadVueltaSpawn = 1f;

    public GameObject pedido_1;
    public GameObject pedido_2;
    public GameObject pedido_3;

    private GameManager gameManager;
    private NavMeshAgent navMeshAgent;

    public Animator animator;

    private bool condici�n = true;

    private void Start()
    {
        posicionSpawn = transform.position;

        gameManager = FindAnyObjectByType<GameManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on this GameObject.");
        }
    }

    public void RealizarPedido()
    {
        // Verificar si ya se ha realizado un pedido
        if (tipoPedido != null)
        {
            Debug.Log("El cliente ya ha realizado su pedido.");
            return;
        }

        // Determinar qu� objeto de pedido instanciar seg�n los platos disponibles en la escena
        tipoPedido = ObtenerPedidoBasadoEnPlatosDisponibles();
        if (tipoPedido == null)
        {
            Debug.LogError("No hay platos disponibles en la escena.");
            return;
        }

        GameObject pedidoObjeto = null;
        switch (tipoPedido)
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

        if (pedidoObjeto != null)
        {
            pedidoObjeto.transform.parent = transform;
            pedidoObjeto.transform.localPosition = Vector3.up;
            Debug.Log("El cliente ha realizado el pedido de: " + tipoPedido);
        }
    }

    private string ObtenerPedidoBasadoEnPlatosDisponibles()
    {
        Plato_1[] platosTipo1 = FindObjectsOfType<Plato_1>();
        Plato_2[] platosTipo2 = FindObjectsOfType<Plato_2>();
        Plato_3[] platosTipo3 = FindObjectsOfType<Plato_3>();

        bool hayPlato1 = platosTipo1.Length > 0;
        bool hayPlato2 = platosTipo2.Length > 0;
        bool hayPlato3 = platosTipo3.Length > 0;

        if (hayPlato1 && hayPlato2 && hayPlato3)
        {
            // Todos los tipos de plato est�n disponibles
            int randomIndex = Random.Range(0, 3);
            switch (randomIndex)
            {
                case 0: return "Plato1";
                case 1: return "Plato2";
                case 2: return "Plato3";
            }
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

    public bool PedidoEsCorrecto(string tipoPlatoEntregado)
    {
        return tipoPlatoEntregado == tipoPedido;
    }

    public void PedidoCompletado()
    {
        pedidoCompletado = true;
        Debug.Log("�Pedido completado por el cliente en la mesa!");

        gameManager.SumarDinero();
        // Iniciar el movimiento de vuelta al spawn
        StartCoroutine(MoverHaciaSpawn());
    }

    private IEnumerator MoverHaciaSpawn()
    {
        ClienteSeLevanta();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on this GameObject.");
            yield break;
        }

        navMeshAgent.SetDestination(posicionSpawn);

        while (!navMeshAgent.pathPending && navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            yield return null;
        }

        // Limpiar el pedido y reiniciar el cliente
        tipoPedido = null;
        pedidoCompletado = false;

        Debug.Log("Cliente ha vuelto al punto de spawn.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mesa") && condici�n == true)
        {
            animator.SetBool("SubirSilla", true);
        }
    }

    public void ClienteSeLevanta()
    {
        condici�n = false;
        animator.SetBool("SubirSilla", false);
    }
}
