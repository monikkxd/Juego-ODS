// GameManager
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Mesa> mesas;
    public List<Cliente> clientes;
    public List<Cocinero> cocineros;
    public Jugador jugador;
    public Transform barraDePlatos;

    public float tiempoEntreApariciones = 4f;
    public float tiempoEntreAparicionesClientes = 4f;

    public Transform puntoDeInstanciaCocineros;
    public Transform puntoDeInstanciaClientes;

    void Start()
    {
        // Inicialización del juego
        InvokeRepeating("AparecerCocinero", 3f, tiempoEntreApariciones);
        InvokeRepeating("AparecerCliente", 2f, tiempoEntreAparicionesClientes);
    }

    void AparecerCocinero()
    {
        foreach (Cocinero cocinero in cocineros)
        {
            cocinero.MoverCocinero(puntoDeInstanciaCocineros.position);
        }
    }

    void AparecerCliente()
    {
        Debug.Log("Apareciendo Cliente");

        if (clientes.Count > 0 && clientes[0] != null)
        {
            Mesa mesaAsignada = mesas[Random.Range(0, mesas.Count)];
            InstanciarCliente(puntoDeInstanciaClientes.position, mesaAsignada.transform);
        }
        else
        {
            Debug.LogError("Prefab de cliente no asignado en la lista de clientes del GameManager.");
        }
    }

    void InstanciarCliente(Vector3 posicionDeInstancia, Transform posicionMesa)
    {
        GameObject nuevoCliente = Instantiate(clientes[0].gameObject, posicionDeInstancia, Quaternion.identity);
        Cliente clienteScript = nuevoCliente.GetComponent<Cliente>();
        clienteScript.IniciarMovimiento(posicionDeInstancia, posicionMesa);
    }

    void Update()
    {
        // Lógica del juego (verificar pedidos, entregar platos, etc.)
    }
}
