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
    public GameObject particulas1;
    public GameObject particulas2;

    public Text absorbedObjectsText; // Referencia al componente UI Text

    private bool isAbsorbing = false;
    private int absorbedObjectCount = 0; // Contador de objetos absorbidos
    private float previousScaleZ;

    void Start()
    {
        // Inicializa el texto del contador
        UpdateAbsorbedObjectsText();
        previousScaleZ = transform.localScale.z;
    }

    void Update()
    {
        // Comprueba si se ha presionado la tecla para activar el absorber
        if (Input.GetKey(absorberKey))
        {
            // Solo llama a ToggleAbsorber si no está ya activado
            if (!isAbsorbing)
            {
                ToggleAbsorber(true);
            }
            else
            {
                // Comprueba si la escala en Z ha cambiado mientras está absorbiendo
                if (transform.localScale.z != previousScaleZ)
                {
                    UpdateParticles();
                    previousScaleZ = transform.localScale.z;
                }
            }
        }
        else
        {
            // Solo llama a ToggleAbsorber si está activado
            if (isAbsorbing)
            {
                ToggleAbsorber(false);
            }
        }
    }

    void ToggleAbsorber(bool activate)
    {
        isAbsorbing = activate;

        if (isAbsorbing)
        {
            // Activa el collider de absorción
            GetComponent<SphereCollider>().enabled = true;

            // Activa el game object de partículas según la escala en el eje Z
            UpdateParticles();
        }
        else
        {
            // Desactiva el collider de absorción
            GetComponent<SphereCollider>().enabled = false;
            // Desactiva ambos game objects de partículas
            particulas1.SetActive(false);
            particulas2.SetActive(false);
        }
    }

    void UpdateParticles()
    {
        if (transform.localScale.z == 1)
        {
            particulas1.SetActive(true);
            particulas2.SetActive(false);
        }
        else if (transform.localScale.z == -1)
        {
            particulas1.SetActive(false);
            particulas2.SetActive(true);
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
