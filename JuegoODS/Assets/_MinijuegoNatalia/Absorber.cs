using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class Absorber : MonoBehaviour
{
    public KeyCode absorberKey = KeyCode.Space; // Tecla para activar el absorber
    public float absorberRadius = 5f; // Radio del collider de absorción
    public string objectTag = "Basura"; // Tag de los objetos a absorber
    public Transform targetPosition; // Posición a la que se moverán los objetos absorbidos
    public GameObject particulas;

    public Text absorbedObjectsText; // Referencia al componente UI Text



    private bool isAbsorbing = false;

    private int absorbedObjectCount = 0; // Contador de objetos absorbidos

    void Start()
    {
        // Inicializa el texto del contador
        UpdateAbsorbedObjectsText();
    }

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
            // Activa el collider de absorción
            GetComponent<SphereCollider>().enabled = true;
            // Activa el game object de partículas
            particulas.SetActive(true);

        }
        else
        {
            // Desactiva el collider de absorción
            GetComponent<SphereCollider>().enabled = false;
            // Desactiva el game object de partículas
            particulas.SetActive(false);
        }
    }

    // Este método se llama cuando otro objeto entra en el collider de absorción
    void OnTriggerEnter(Collider other)
    {
        if (isAbsorbing && other.gameObject.CompareTag(objectTag))
        {


            // Incrementa el contador de objetos absorbidos
            absorbedObjectCount++;

            // Actualiza el texto en pantalla
            UpdateAbsorbedObjectsText();

            // Realiza alguna acción con el objeto absorbido
            Debug.Log("Objeto absorbido: " + other.gameObject.name);
            Debug.Log("Total de objetos absorbidos: " + absorbedObjectCount);

            
            // Mueve el objeto absorbido a la posición predefinida
            other.transform.position = targetPosition.position;

            // Destruye el objeto absorbido después de un breve retraso
            Destroy(other.gameObject, 0.5f);
        }
    }

    void UpdateAbsorbedObjectsText()
    {
        absorbedObjectsText.text = "Objetos absorbidos: " + absorbedObjectCount;
    }

    // Función opcional para obtener el número de objetos absorbidos
    public int GetAbsorbedObjectCount()
    {
        return absorbedObjectCount;
    }
}

