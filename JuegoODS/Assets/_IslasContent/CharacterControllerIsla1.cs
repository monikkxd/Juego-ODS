using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerIsla1 : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float rotationSpeed = 100f; // Velocidad de rotación

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Obtener la entrada del teclado para el movimiento
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed * Time.deltaTime;

        // Aplica el movimiento al rigidbody
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // Obtener la entrada del teclado para la rotación
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Calcula la rotación
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotation, 0) * Time.deltaTime);

        // Aplica la rotación al rigidbody
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
