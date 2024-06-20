using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interacter : MonoBehaviour
{
    private Transform interactuador;

    private bool tocandoBotón = false;

    public GameObject transición;
    public GameObject Indicador;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tocandoBotón)
        {
            transición.SetActive(true);
            Invoke("Interactuar", 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            Indicador.SetActive(true);
            tocandoBotón = true;
        }
        else if (other.CompareTag("Plato"))
        {
            Indicador.SetActive(true);
        }
        else if (other.CompareTag("Mesa"))
        {
            Indicador.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Indicador.SetActive(false);
            tocandoBotón = false;
        }
        else if (other.CompareTag("Plato"))
        {
            Indicador.SetActive(false);
        }
        else if (other.CompareTag("Mesa"))
        {
            Indicador.SetActive(false);
        }
    }


    void Interactuar()
    {
        SceneManager.LoadScene("MinigameSelectionClara");
    }
}
