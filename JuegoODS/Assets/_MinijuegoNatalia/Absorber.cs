using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorber : MonoBehaviour
{
    public KeyCode absorberKey = KeyCode.Space; // Tecla para activar el absorber
    public float absorberRadius = 5f; // Radio del collider de absorci�n

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
            // Activa el collider de absorci�n
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            // Desactiva el collider de absorci�n
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    // Este m�todo se llama cuando otro objeto entra en el collider de absorci�n
    void OnTriggerEnter(Collider other)
    {
        if (isAbsorbing)
        {
            // Realiza alguna acci�n con el objeto absorbido
            Debug.Log("Objeto absorbido: " + other.gameObject.name);

            // Puedes hacer lo que quieras con el objeto absorbido aqu�
            // Por ejemplo, puedes destruirlo, desactivarlo, cambiar su posici�n, etc.
            // other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
    }
}

