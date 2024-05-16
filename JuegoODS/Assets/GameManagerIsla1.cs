using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIslas1 : MonoBehaviour
{
    public GameObject minijuegoNatalia;
    public GameObject minijuegoAlex;

    public GameObject arbolesMal;
    public GameObject arbolesBien;
    public GameObject bolsasBasura;
    void Start()
    {
       
        if (CambioEscenasIslas.previousSceneName == "MinijuegoAndrea")
        {
            minijuegoNatalia.SetActive(true);
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
        minijuegoAlex.SetActive(true);
    }

}
