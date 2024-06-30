using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EliminarTierra : MonoBehaviour
{
    public Slider healthSlider; // Referencia al Slider
    public float damageAmount = 10f; // Cantidad de decremento en cada colisión
    // Referencia a la imagen que queremos activar
    public Image imageToActivate;

    // Inicializa el Slider al máximo al comienzo del juego
    void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = 80; // Establecer el valor máximo del Slider
            healthSlider.value = healthSlider.maxValue;
        }
    }

    // Método que se llama cuando un objeto entra en el collider
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);

        if (collider.tag == "TIERRA")
        {

            // ANIMACION CAVAR
            Destroy(collider.gameObject);
            Debug.Log("Objeto destruido: " + collider.gameObject.name);
        }

        if (collider.tag == "MetaAgua")
        {
            StartCoroutine(ActivateImageRoutine());

            
        }

        if (collider.tag == "ALTERADORCALIDAD")
        {
            // Disminuir el valor del Slider
            healthSlider.value -= damageAmount;
            Debug.Log("Objeto afectado: " + collider.gameObject.name);


            // Asegurarse de que el Slider no baje de 0
            if (healthSlider.value < 0)
            {
                healthSlider.value = 0;
            }
            
        }

        
    }
    
    // Corrutina que activa la imagen y espera 5 segundos
    private IEnumerator ActivateImageRoutine()
    {
        // Activar la imagen
        imageToActivate.gameObject.SetActive(true);

        // Esperar 5 segundos
        yield return new WaitForSeconds(5f);

        //AQUI VA EL CAMBIO DE ESCENA.
        SelectorNivel.monicaCompletado = true;
        SceneManager.LoadScene("SelecciónNivel");
        Debug.Log("AGUA AL PUEBLO ");

        // Aquí puedes agregar la acción que deseas realizar después de los 5 segundos
        Debug.Log("5 segundos han pasado. Puedes realizar otra acción aquí.");
    }
}

