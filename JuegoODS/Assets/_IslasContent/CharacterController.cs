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

        // Calcular la dirección de movimiento en base a la perspectiva isométrica
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        // Aplicar el movimiento en la dirección adecuada
        transform.Translate(movement * speed * Time.deltaTime);

        // Rotar el personaje para que siempre esté orientado en la dirección de movimiento
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }
}



