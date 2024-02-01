using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Movimiento_Horizontal : MonoBehaviour
{
    public float velocidadMaxima = 5f; 
    public float suavidadMovimiento = 5f; 
    private float mZCoord;
    private Rigidbody rb;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        rb.isKinematic = false; 
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
        mousePosition.y = transform.position.y; 

        Vector3 nuevaPosicion = Vector3.Lerp(transform.position, mousePosition, suavidadMovimiento * Time.deltaTime);
        rb.MovePosition(nuevaPosicion);
    }

    void OnMouseUp()
    {
        rb.isKinematic = true; 
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normalDeColision = collision.contacts[0].normal;
    }
}
