using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{

    // Referencia a la imagen que queremos activar
    public Image imageToActivate;

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que se ha colisionado tiene la etiqueta "meta"
        if (other.CompareTag("meta"))
        {

            StartCoroutine(ActivateImageRoutine());
            
        }
    }

    private IEnumerator ActivateImageRoutine()
    {
        // Activar la imagen
        imageToActivate.gameObject.SetActive(true);

        // Esperar 5 segundos
        yield return new WaitForSeconds(5f);

        SelectorNivel.andreaCompletado = true;
        // Mostrar el texto de "Meta"
        Debug.Log("Meta");
        SceneManager.LoadScene("SelecciónNivel");

        // Aquí puedes agregar la acción que deseas realizar después de los 5 segundos
        Debug.Log("5 segundos han pasado. Puedes realizar otra acción aquí.");
    }
}

