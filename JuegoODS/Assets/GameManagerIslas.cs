using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIslas : MonoBehaviour
{
    public GameObject minijuegoNatalia;
    public GameObject minijuegoAndrea;
    public GameObject minijuegoAlex;
    void Start()
    {
        if(minijuegoNatalia.activeSelf == true && minijuegoAndrea.activeSelf == true)
        {
            ActivarMinijuegoAlex();
        }

        if (CambioEscenasIslas.previousSceneName == "MinijuegoAndrea")
        {
            minijuegoNatalia.SetActive(true);
        }
    }
     
    private void ActivarMinijuegoAlex()
    {
        minijuegoAlex.SetActive(true);
    }

}
