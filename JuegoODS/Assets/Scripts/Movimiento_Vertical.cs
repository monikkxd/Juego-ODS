using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Movimiento_Vertical : MonoBehaviour
{
    public float velocidadMaxima = 5f; // Ajusta esta variable según sea necesario
    public float suavidadMovimiento = 5f; // Ajusta la suavidad del movimiento
    private float mZCoord;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Desactivamos la física inicialmente
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ; // Bloqueamos la rotación y el movimiento en Z
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb.isKinematic = false; // Activamos la física para permitir colisiones
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = GetMouseAsWorldPoint();
        mousePosition.x = transform.position.x; // Mantener la posición X original

        // Calcular la nueva posición del objeto utilizando Lerp solo en el eje Y
        Vector3 targetPosition = new Vector3(transform.position.x, mousePosition.y, transform.position.z);
        rb.velocity = (targetPosition - transform.position * velocidadMaxima) * suavidadMovimiento;
    }

    void OnMouseUp()
    {
        rb.isKinematic = true; // Desactivamos la física al soltar el mouse
        rb.velocity = Vector3.zero; // Detenemos la velocidad al soltar el mouse
    }

    void OnCollisionEnter(Collision collision)
    {
        // Rebotar ligeramente en la dirección contraria
        Vector3 normalDeColision = collision.contacts[0].normal;
    }
}
