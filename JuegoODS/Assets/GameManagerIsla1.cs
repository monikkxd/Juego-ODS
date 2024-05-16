using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIslas1 : MonoBehaviour
{
    public GameObject minijuegoNatalia;
    public GameObject minijuegoAndrea;
    public GameObject minijuegoAlex;
    void Start()
    {
        if (minijuegoNatalia.activeSelf == true && minijuegoAndrea.activeSelf == true)
        {
            ActivarMinijuegoAlex();
        }

        if (CambioEscenasIslas.previousSceneName == "MinijuegoAndrea")
        {
            minijuegoNatalia.SetActive(true);
        }
        else if (CambioEscenasIslas.previousSceneName == "MinijuegoNatalia")
        {
            minijuegoAndrea.SetActive(true);
        }
    }

    private void ActivarMinijuegoAlex()
    {
        Debug.Log("Minijuego Alex activado");
        minijuegoAlex.SetActive(true);
    }

}
