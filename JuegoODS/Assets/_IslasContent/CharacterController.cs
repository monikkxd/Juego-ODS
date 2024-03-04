using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterController : MonoBehaviour
{
    public float speed = 5.0f;

    private void Update()
    {
        // Obtener las entradas de los ejes horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la direcci�n de movimiento en base a la perspectiva isom�trica
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        // Aplicar el movimiento en la direcci�n adecuada
        transform.Translate(movement * speed * Time.deltaTime);

        // Rotar el personaje para que siempre est� orientado en la direcci�n de movimiento
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }
}



