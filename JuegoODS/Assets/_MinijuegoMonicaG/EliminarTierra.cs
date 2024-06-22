using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EliminarTierra : MonoBehaviour
{
    

    // M�todo para activar el collider cuando se presiona la tecla E
    void Update()
    {
        
    }

    
    

    // M�todo que se llama cuando un objeto entra en el collider
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);

        if (collider.tag == "TIERRA")
        {
            Destroy(collider.gameObject);
            Debug.Log("Objeto destruido: " + collider.gameObject.name);
        }

        if (collider.tag == "MetaAgua")
        {
            //AQUI VA EL CAMBIO DE ESCENA.
            SelectorNivel.monicaCompletado = true;
            SceneManager.LoadScene("Selecci�nNivel");
            Debug.Log("AGUA AL PUEBLO ");
        }
    }
}

