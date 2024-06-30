using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateImage : MonoBehaviour
{
    // Variable para la imagen que se va a desactivar
    public Image imageToDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        // Inicia la corrutina que desactiva la imagen después de 5 segundos
        StartCoroutine(DeactivateAfterSeconds(5));
    }

    // Corrutina para desactivar la imagen
    IEnumerator DeactivateAfterSeconds(float seconds)
    {
        // Espera la cantidad de segundos especificada
        yield return new WaitForSeconds(seconds);

        // Desactiva la imagen
        imageToDeactivate.gameObject.SetActive(false);
    }
}

