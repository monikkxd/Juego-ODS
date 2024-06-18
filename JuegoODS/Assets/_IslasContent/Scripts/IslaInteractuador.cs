using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslaInteractuador : MonoBehaviour
{
    private Transform interactuador;

    // Rango de interacci�n
    public float rangoInteraccion = 2f;

    public GameObject transici�n;
    public GameObject di�logo;

    void Start()
    {
        interactuador = transform.Find("Interactuador");

        if (interactuador == null)
        {
            Debug.LogError("No se encontr� el objeto interactuador. Aseg�rate de que el nombre del hijo sea 'Interactuador'.");
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
            if (hit.collider.CompareTag("Minijuego Andrea"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoAndrea();
            }
            else if (hit.collider.CompareTag("Minijuego  Natalia"))
            {
                transici�n.SetActive(true);
                Invoke("CambioEscenaNatalia", 2f);
            }
            else if (hit.collider.CompareTag("Minijuego Alex"))
            {
                Debug.Log("Cargando Juego Alex");
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoAlex();
            }
            else if (hit.collider.CompareTag("MinijuegoAlex2"))
            {
                Debug.Log("Cargando Juego Alex");
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoAlex2();
            }
            else if (hit.collider.CompareTag("MinijuegoMonicaG"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoMonicaG();
            }
            else if (hit.collider.CompareTag("MinijuegoHugo"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoHugo();
            }
            else if (hit.collider.CompareTag("MinijuegoMario"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoMario();
            }
            else if (hit.collider.CompareTag("MinijuegoMigui"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoMigui();
            }
            else if (hit.collider.CompareTag("MinijuegoClara"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoClara();
            }
            else if (hit.collider.CompareTag("MinijuegoMoni"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoMoni();
            }
            else if (hit.collider.CompareTag("Final"))
            {
                transici�n.SetActive(true);
                Invoke("CambioEscena2", 2f);
            }
            else if(hit.collider.CompareTag("Mr.Mondongo"))
            {
                di�logo.SetActive(true);
                Invoke("Transici�n", 7f); 
                Invoke("CambioEscena", 10f);
            }
        }
    }

    void Transici�n()
    {
        transici�n.SetActive(true);
    }
    void CambioEscena()
    {
        SceneManager.LoadScene("Selecci�nNivel");
    }
    void CambioEscena2()
    {
        SceneManager.LoadScene("EscenaFinal");
    }
    void CambioEscenaNatalia()
    {
        SceneManager.LoadScene("_MontajeEscenaNatalia");
    }
}
