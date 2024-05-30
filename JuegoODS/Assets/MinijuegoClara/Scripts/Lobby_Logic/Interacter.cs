using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    private Transform interactuador;

    // Rango de interacción
    public float rangoInteraccion = 2f;

    void Start()
    {
        interactuador = transform.Find("Interactuador");

        if (interactuador == null)
        {
            Debug.LogError("No se encontró el objeto interactuador. Asegúrate de que el nombre del hijo sea 'Interactuador'.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }

    void Interactuar()
    {
        RaycastHit hit;
        if (Physics.Raycast(interactuador.position, interactuador.forward, out hit, rangoInteraccion))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                hit.collider.GetComponent<InteractableObject>().Interactuar();
            }
        }
    }
}
