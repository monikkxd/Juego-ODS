using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class Absorber : MonoBehaviour
{
    public KeyCode absorberKey = KeyCode.Space; // Tecla para activar el absorber
    public float absorberRadius = 5f; // Radio del collider de absorci�n
    public string objectTag = "Basura"; // Tag de los objetos a absorber
    public Transform targetPosition; // Posici�n a la que se mover�n los objetos absorbidos
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
            // Solo llama a ToggleAbsorber si no est� ya activado
            if (!isAbsorbing)
            {
                ToggleAbsorber(true);
            }
            else
            {
                // Comprueba si la escala en Z ha cambiado mientras est� absorbiendo
                if (transform.localScale.z != previousScaleZ)
                {
                    UpdateParticles();
                    previousScaleZ = transform.localScale.z;
                }
            }
        }
        else
        {
            // Solo llama a ToggleAbsorber si est� activado
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
            // Activa el collider de absorci�n
            GetComponent<SphereCollider>().enabled = true;

            // Activa el game object de part�culas seg�n la escala en el eje Z
            UpdateParticles();
        }
        else
        {
            // Desactiva el collider de absorci�n
            GetComponent<SphereCollider>().enabled = false;
            // Desactiva ambos game objects de part�culas
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

    // Este m�todo se llama cuando otro objeto entra en el collider de absorci�n
    void OnTriggerEnter(Collider other)
    {
        if (isAbsorbing && other.gameObject.CompareTag(objectTag))
        {
            // Incrementa el contador de objetos absorbidos
            absorbedObjectCount++;

            // Actualiza el texto en pantalla
            UpdateAbsorbedObjectsText();

            // Realiza alguna acci�n con el objeto absorbido
            Debug.Log("Objeto absorbido: " + other.gameObject.name);
            Debug.Log("Total de objetos absorbidos: " + absorbedObjectCount);

            // Mueve el objeto absorbido a la posici�n predefinida
            other.transform.position = targetPosition.position;

            // Destruye el objeto absorbido despu�s de un breve retraso
            Destroy(other.gameObject, 0.5f);
        }
    }

    void UpdateAbsorbedObjectsText()
    {
        absorbedObjectsText.text = "Objetos absorbidos: " + absorbedObjectCount;
    }

    // Funci�n opcional para obtener el n�mero de objetos absorbidos
    public int GetAbsorbedObjectCount()
    {
        return absorbedObjectCount;
    }
}
