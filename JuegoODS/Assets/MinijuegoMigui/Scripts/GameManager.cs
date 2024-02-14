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
            Transform puntoEnLaBarra = ObtenerPuntoAleatorioEnLaBarra();
            cocinero.MoverCocinero(puntoDeInstanciaCocineros.position, puntoEnLaBarra);
        }
    }

    void AparecerCliente()
    {
        foreach (Cliente cliente in clientes)
        {
            Mesa mesaAsignada = mesas[Random.Range(0, mesas.Count)];
            InstanciarCliente(puntoDeInstanciaClientes.position, mesaAsignada.transform);
        }
    }

    // Método para instanciar el cliente
    void InstanciarCliente(Vector3 posicionDeInstancia, Transform posicionMesa)
    {
        GameObject nuevoCliente = Instantiate(clientes[0].gameObject, posicionDeInstancia, Quaternion.identity);
        Cliente clienteScript = nuevoCliente.GetComponent<Cliente>();
        clienteScript.IniciarMovimiento(posicionDeInstancia, posicionMesa);
    }

    Transform ObtenerPuntoAleatorioEnLaBarra()
    {
        if (barraDePlatos.childCount > 0)
        {
            int indiceAleatorio = Random.Range(0, barraDePlatos.childCount);
            return barraDePlatos.GetChild(indiceAleatorio);
        }
        else
        {
            Debug.LogError("No hay puntos en la barra de platos.");
            return null;
        }
    }

    void Update()
    {
        // Lógica del juego (verificar pedidos, entregar platos, etc.)
    }
}
