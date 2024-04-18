using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarObjetos : MonoBehaviour
{
    public float radioDeteccion = 5f; // Radio de detección del personaje
    public LayerMask capasObjetos; // Capas que incluyen los objetos que queremos detectar

    // Método para detectar los objetos cercanos al personaje
    public void Detectar()
    {
        // Obtener todos los colliders dentro del radio de detección del personaje
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioDeteccion, capasObjetos);

        // Iterar a través de los colliders detectados
        foreach (Collider collider in colliders)
        {
            // Verificar si el objeto detectado tiene la tag "pez payaso" o "pez dori"
            if (collider.CompareTag("pez payaso"))
            {
                Debug.Log("¡Pez payaso detectado!");
                // Aquí puedes agregar el código para lo que quieras que suceda cuando se detecta un pez payaso
            }
            else if (collider.CompareTag("pez dori"))
            {
                Debug.Log("¡Pez dori detectado!");
                // Aquí puedes agregar el código para lo que quieras que suceda cuando se detecta un pez dori
            }
        }
    }
}

