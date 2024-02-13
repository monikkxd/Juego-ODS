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
        foreach (Cliente cliente in clientes)
        {
            
            Mesa mesaAsignada = mesas[Random.Range(0, mesas.Count)];
            
            cliente.MoverCliente(puntoDeInstanciaClientes.position, mesaAsignada);
        }
    }
    void Update()
    {
        
    }

    


}
