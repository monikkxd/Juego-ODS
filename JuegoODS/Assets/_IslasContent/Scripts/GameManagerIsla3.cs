using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIsla3 : MonoBehaviour
{
    public GameObject minijuegoClara;
    public GameObject minijuegoMigui;

    public GameObject arbolesMal;
    public GameObject arbolesBien;
    public GameObject bolsasBasura;
    void Start()
    {

        if (CambioEscenasIslas.previousSceneName == "MinijuegoAndrea")
        {
            minijuegoClara.SetActive(true);
            bolsasBasura.SetActive(true);
            arbolesMal.SetActive(false);
            arbolesBien.SetActive(true);
        }
        else if (CambioEscenasIslas.previousSceneName == "Lobby Minijuegos Clara")
        {
            ActivarMinijuegoAlex();
            arbolesMal.SetActive(false);
            bolsasBasura.SetActive(false);
            arbolesBien.SetActive(true);
        }

    }

    private void ActivarMinijuegoAlex()
    {
        Debug.Log("Minijuego Alex activado");
        minijuegoMigui.SetActive(true);
    }

}
