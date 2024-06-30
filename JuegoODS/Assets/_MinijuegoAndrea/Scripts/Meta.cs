using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que se ha colisionado tiene la etiqueta "meta"
        if (other.CompareTag("meta"))
        {
            SelectorNivel.andreaCompletado = true;
            // Mostrar el texto de "Meta"
            Debug.Log("Meta");
            SceneManager.LoadScene("SelecciónNivel");
        }
    }
}

