using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorber : MonoBehaviour
{
    public KeyCode absorberKey = KeyCode.Space; // Tecla para activar el absorber
    public float absorberRadius = 5f; // Radio del collider de absorción

    private bool isAbsorbing = false;

    void Update()
    {
        // Comprueba si se ha presionado la tecla para activar el absorber
        if (Input.GetKeyDown(absorberKey))
        {
            ToggleAbsorber();
        }
    }

    void ToggleAbsorber()
    {
        isAbsorbing = !isAbsorbing;

        if (isAbsorbing)
        {
            // Activa el collider de absorción
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            // Desactiva el collider de absorción
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    // Este método se llama cuando otro objeto entra en el collider de absorción
    void OnTriggerEnter(Collider other)
    {
        if (isAbsorbing)
        {
            // Realiza alguna acción con el objeto absorbido
            Debug.Log("Objeto absorbido: " + other.gameObject.name);

            // Puedes hacer lo que quieras con el objeto absorbido aquí
            // Por ejemplo, puedes destruirlo, desactivarlo, cambiar su posición, etc.
            // other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
    }
}

