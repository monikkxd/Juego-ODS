using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYEliminar : MonoBehaviour
{
    public float speed = 5f; // Velocidad de desplazamiento hacia adelante
    private Renderer obstacleRenderer;

    void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Desplazamiento hacia adelante
        transform.Translate(Vector3.left * speed * Time.deltaTime); //para pasar al otro lado "right"

        // Si el obstáculo ya no está visible en la pantalla, eliminarlo
        if (!obstacleRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}

