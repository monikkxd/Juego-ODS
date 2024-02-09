using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LógicaJugador : MonoBehaviour
{
    public GameObject jugadorPrefab; // Variable para el prefab del jugador

    void Start()
    {
        // Instanciar el jugador en la posición (0.5, 0, 0.5) de la cuadrícula
        GameObject jugador = Instantiate(jugadorPrefab, new Vector3(0.5f, 0, 0.5f), Quaternion.identity);
    }

    void Update()
    {
        // Puedes agregar lógica adicional para el jugador aquí si es necesario
    }
}
