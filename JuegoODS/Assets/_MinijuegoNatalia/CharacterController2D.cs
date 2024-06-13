using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 5f;
    public float verticalSpeed = 5f; // Velocidad vertical

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = -Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Cambiar escala en el eje Z
        if (moveInput > 0)
        {
            // Moviéndose a la derecha
            Vector3 scaler = transform.localScale;
            scaler.z = -1;
            transform.localScale = scaler;
        }
        else if (moveInput < 0)
        {
            // Moviéndose a la izquierda
            Vector3 scaler = transform.localScale;
            scaler.z = 1;
            transform.localScale = scaler;
        }

        // Movimiento vertical
        float moveInputVertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveInputVertical * verticalSpeed);
    }
}
