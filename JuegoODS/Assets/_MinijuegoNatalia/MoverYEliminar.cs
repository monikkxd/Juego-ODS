using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYEliminar : MonoBehaviour
{
    public float speed = 5f; // Velocidad de desplazamiento hacia adelante
    public float destroyXPosition = -10f; // Posici�n en la que se destruir� el objeto

    void Update()
    {
        // Desplazamiento hacia adelante
        transform.Translate(Vector3.left * speed * Time.deltaTime); //para pasar al otro lado "right"

        // Si el objeto llega a la posici�n de destrucci�n, eliminarlo
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}


