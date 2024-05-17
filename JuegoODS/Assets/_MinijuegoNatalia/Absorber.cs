using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorber : MonoBehaviour
{
    public KeyCode absorberKey = KeyCode.Space; // Tecla para activar el absorber
    public float absorberRadius = 5f; // Radio del collider de absorci�n
    public string objectTag = "Basura"; // Tag de los objetos a absorber
    public Transform targetPosition; // Posici�n a la que se mover�n los objetos absorbidos
    public GameObject particulas;

    private bool isAbsorbing = false;

    void Update()
    {
        // Comprueba si se ha presionado la tecla para activar el absorber
        if (Input.GetKey(absorberKey))
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
            // Activa el game object de part�culas
            particulas.SetActive(true);

        }
        else
        {
            // Desactiva el collider de absorci�n
            GetComponent<SphereCollider>().enabled = false;
            // Desactiva el game object de part�culas
            particulas.SetActive(false);
        }
    }

    // Este m�todo se llama cuando otro objeto entra en el collider de absorci�n
    void OnTriggerEnter(Collider other)
    {
        if (isAbsorbing && other.gameObject.CompareTag(objectTag))
        {
            // Realiza alguna acci�n con el objeto absorbido
            Debug.Log("Objeto absorbido: " + other.gameObject.name);

            // Mueve el objeto absorbido a la posici�n predefinida
            other.transform.position = targetPosition.position;

            // Destruye el objeto absorbido despu�s de un breve retraso
            Destroy(other.gameObject, 0.5f);
        }
    }
}

