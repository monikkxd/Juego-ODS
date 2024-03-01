using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float jumpSpeed = 8f;
    public float gravity = -20f;

    private float turnSmoothVelocity;
    private float verticalVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Verificar si se ha presionado el botón de salto
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            verticalVelocity = jumpSpeed;
        }

        // Aplicar la gravedad
        verticalVelocity += gravity * Time.deltaTime;
        Vector3 gravityVector = new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        controller.Move(gravityVector);
    }
}




