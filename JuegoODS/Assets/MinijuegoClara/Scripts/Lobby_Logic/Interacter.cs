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
            tocandoBotón = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            tocandoBotón = false;
        }
    }


    void Interactuar()
    {
        SceneManager.LoadScene("MinigameSelectionClara");
    }
}
