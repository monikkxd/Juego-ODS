using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interacter : MonoBehaviour
{
    private Transform interactuador;

    private bool tocandoBot�n = false;

    public GameObject transici�n;
    public GameObject Indicador;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tocandoBot�n)
        {
            transici�n.SetActive(true);
            Invoke("Interactuar", 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            Indicador.SetActive(true);
            tocandoBot�n = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Indicador.SetActive(false);
            tocandoBot�n = false;
        }
    }


    void Interactuar()
    {
        SceneManager.LoadScene("MinigameSelectionClara");
    }
}
