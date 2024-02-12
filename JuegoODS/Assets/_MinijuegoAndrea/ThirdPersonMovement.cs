using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //public float jumpForce = 8f; // Nueva variable para controlar la fuerza del salto

    //private bool isGrounded; // Variable para verificar si el personaje está en el suelo

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle= Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        /*
        // Verificar si el personaje está en el suelo
        isGrounded = controller.isGrounded;

        if (isGrounded && Input.GetButtonDown("Jump")) // Si está en el suelo y se presiona el botón de salto
        {
            // Aplicar una fuerza hacia arriba para simular el salto
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
        }
        */
    }
}
