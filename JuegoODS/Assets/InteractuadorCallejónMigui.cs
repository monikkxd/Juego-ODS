using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractuadorCallejónMigui : MonoBehaviour
{
    private Transform interactuador;

    // Rango de interacción
    public float rangoInteraccion = 2f;

    public GameObject diálogoCallejón;
    public GameObject transición;
    public GameObject textoMondonguin;
    void Start()
    {
        interactuador = transform.Find("Interactuador");

        if (interactuador == null)
        {
            Debug.LogError("No se encontró el objeto interactuador. Asegúrate de que el nombre del hijo sea 'Interactuador'.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }

    void Interactuar()
    {
        RaycastHit hit;
        if (Physics.Raycast(interactuador.position, interactuador.forward, out hit, rangoInteraccion))
        {
            if (hit.collider.CompareTag("Mr.Mondongo"))
            {
                diálogoCallejón.SetActive(true);
                textoMondonguin.SetActive(false);
                Invoke("ActivarTransición", 7.5f);
                Invoke("CargarIsla3", 9.5f);
            }
        }
    }

    public void ActivarTransición()
    {
        transición.SetActive(true);
    }

    public void CargarIsla3()
    {
        SceneManager.LoadScene("TerceraIsla");
    }
}
