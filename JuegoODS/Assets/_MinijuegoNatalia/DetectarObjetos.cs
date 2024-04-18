using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarObjetos : MonoBehaviour
{
    public float radioDeteccion = 5f; // Radio de detecci�n del personaje
    public LayerMask capasObjetos; // Capas que incluyen los objetos que queremos detectar

    // M�todo para detectar los objetos cercanos al personaje
    public void Detectar()
    {
        // Obtener todos los colliders dentro del radio de detecci�n del personaje
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioDeteccion, capasObjetos);

        // Iterar a trav�s de los colliders detectados
        foreach (Collider collider in colliders)
        {
            // Verificar si el objeto detectado tiene la tag "pez payaso" o "pez dori"
            if (collider.CompareTag("pez payaso"))
            {
                Debug.Log("�Pez payaso detectado!");
                // Aqu� puedes agregar el c�digo para lo que quieras que suceda cuando se detecta un pez payaso
            }
            else if (collider.CompareTag("pez dori"))
            {
                Debug.Log("�Pez dori detectado!");
                // Aqu� puedes agregar el c�digo para lo que quieras que suceda cuando se detecta un pez dori
            }
        }
    }
}

