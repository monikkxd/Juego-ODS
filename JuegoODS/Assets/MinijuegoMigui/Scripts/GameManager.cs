
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<string> tiposDePlatoDisponibles = new List<string>();

    void Start()
    {
        // Buscar todos los objetos en la escena que tengan componentes de platos
        Plato_Class[] platosEnEscena = FindObjectsOfType<Plato_Class>();

        // Recopilar tipos de platos únicos disponibles en la escena
        foreach (var plato in platosEnEscena)
        {
            string tipoPlato = ObtenerTipoPlato(plato);
            if (!tiposDePlatoDisponibles.Contains(tipoPlato))
            {
                tiposDePlatoDisponibles.Add(tipoPlato);
            }
        }
    }

    private string ObtenerTipoPlato(Plato_Class plato)
    {
        // Determinar el tipo de plato basado en el componente del plato
        if (plato is Plato_1)
        {
            return "Plato1";
        }
        else if (plato is Plato_2)
        {
            return "Plato2";
        }
        else if (plato is Plato_3)
        {
            return "Plato3";
        }
        else
        {
            return "Desconocido";
        }
    }

    public string ObtenerPedidoAleatorio()
    {
        // Seleccionar aleatoriamente un tipo de plato disponible como pedido
        if (tiposDePlatoDisponibles.Count > 0)
        {
            return tiposDePlatoDisponibles[Random.Range(0, tiposDePlatoDisponibles.Count)];
        }
        else
        {
            return "PlatoDefault"; // Si no hay platos disponibles, se devuelve un pedido genérico
        }
    }
}
