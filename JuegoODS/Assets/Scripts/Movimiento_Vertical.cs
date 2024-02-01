using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Movimiento_Vertical : MonoBehaviour
{
    public float velocidadMaxima = 5f; // Ajusta esta variable seg�n sea necesario
    public float suavidadMovimiento = 5f; // Ajusta la suavidad del movimiento
    private float mZCoord;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Desactivamos la f�sica inicialmente
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ; // Bloqueamos la rotaci�n y el movimiento en Z
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb.isKinematic = false; // Activamos la f�sica para permitir colisiones
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
        mousePosition.x = transform.position.x; // Mantener la posici�n X original

        // Calcular la nueva posici�n del objeto utilizando Lerp solo en el eje Y
        Vector3 targetPosition = new Vector3(transform.position.x, mousePosition.y, transform.position.z);
        rb.velocity = (targetPosition - transform.position * velocidadMaxima) * suavidadMovimiento;
    }

    void OnMouseUp()
    {
        rb.isKinematic = true; // Desactivamos la f�sica al soltar el mouse
        rb.velocity = Vector3.zero; // Detenemos la velocidad al soltar el mouse
    }

    void OnCollisionEnter(Collision collision)
    {
        // Rebotar ligeramente en la direcci�n contraria
        Vector3 normalDeColision = collision.contacts[0].normal;
    }
}
