using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public int maxbasura = 5;

    private bool isAbsorbing = false;
    private int absorbedObjectCount = 0; // Contador de objetos absorbidos
    private float previousScaleZ;

    

    // Referencia a la imagen que queremos activar
    public Image imageToActivate;



    

    public GameObject transici�n;

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
            if (!isAbsorbing)
            {
                ToggleAbsorber(true);
            }
            else
            {
                if (transform.localScale.z != previousScaleZ)
                {
                    UpdateParticles();
                    previousScaleZ = transform.localScale.z;
                }
            }
        }
        else
        {
            if (isAbsorbing)
            {
                ToggleAbsorber(false);
            }
        }

        if (absorbedObjectCount >= maxbasura)
        {
            StartCoroutine(ActivateImageRoutine());
        }
    }

    void ToggleAbsorber(bool activate)
    {
        isAbsorbing = activate;

        if (isAbsorbing)
        {
            GetComponent<SphereCollider>().enabled = true;

            UpdateParticles();
        }
        else
        {
            GetComponent<SphereCollider>().enabled = false;
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
        absorbedObjectsText.text = "Basura recogida: " + absorbedObjectCount + "/" + maxbasura;
    }

    // Funci�n opcional para obtener el n�mero de objetos absorbidos
    public int GetAbsorbedObjectCount()
    {
        return absorbedObjectCount;
    }

    private IEnumerator ActivateImageRoutine()
    {
        // Activar la imagen
        imageToActivate.gameObject.SetActive(true);

        // Esperar 5 segundos
        yield return new WaitForSeconds(5f);

        SelectorNivel.nataliaCompletado = true;
        

        transici�n.SetActive(true);
        SceneManager.LoadScene("Selecci�nNivel");

        // Aqu� puedes agregar la acci�n que deseas realizar despu�s de los 5 segundos
        Debug.Log("5 segundos han pasado. Puedes realizar otra acci�n aqu�.");
    }
}
