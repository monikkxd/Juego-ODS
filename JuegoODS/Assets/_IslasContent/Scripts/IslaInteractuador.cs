using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslaInteractuador : MonoBehaviour
{
    private Transform interactuador;

    // Rango de interacción
    public float rangoInteraccion = 2f;

    public GameObject transición;
    public GameObject diálogo;

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
            if (hit.collider.CompareTag("Minijuego Andrea"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoAndrea();
            }
            else if (hit.collider.CompareTag("Minijuego  Natalia"))
            {
                hit.collider.GetComponent<IslaInteractable>().CargarMinijuegoNatalia();
            }
            else if (hit.collider.CompareTag("MinijuegoAlex"))
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
            else if(hit.collider.CompareTag("Mr.Mondongo"))
            {
                diálogo.SetActive(true);
                Invoke("Transición", 2f);
                Invoke("CambioEscena", 4.5f);
            }
        }
    }

    void Transición()
    {
        transición.SetActive(true);
    }
    void CambioEscena()
    {
        SceneManager.LoadScene("TerceraIsla2");
    }
}
