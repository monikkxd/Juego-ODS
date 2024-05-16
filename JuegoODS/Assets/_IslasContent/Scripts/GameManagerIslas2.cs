using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIslas2 : MonoBehaviour
{
    public GameObject minijuegoMonicaG;
    public GameObject minijuegoMario;

    public GameObject arbolesMal;
    public GameObject arbolesBien;
    public GameObject bolsasBasura;
    void Start()
    {

        if (CambioEscenasIslas.previousSceneName == "MinijuegoAndrea")
        {
            minijuegoMario.SetActive(true);
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
        minijuegoMonicaG.SetActive(true);
    }

}
