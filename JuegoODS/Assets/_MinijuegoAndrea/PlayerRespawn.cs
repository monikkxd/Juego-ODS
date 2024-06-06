using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    // Posición de respawn preestablecida
    public Vector3 respawnPosition;

    // Método que se llama al comenzar el juego
    void Start()
    {
        // Puedes inicializar la posición de respawn aquí o establecerla en el editor
        // respawnPosition = new Vector3(0, 0, 0); // Ejemplo de inicialización
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que se ha colisionado tiene la etiqueta "meta"
        if (other.CompareTag("muerte"))
        {
            // Mostrar el texto de "Meta"
            Debug.Log("Muerte");

            SceneManager.LoadScene("_MontajeEscenaAndrea");
        }
    }
}

