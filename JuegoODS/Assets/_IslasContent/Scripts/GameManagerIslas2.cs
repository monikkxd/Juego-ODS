using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIslas2 : MonoBehaviour
{
    public GameObject minijuegoMonicaG;
    public GameObject minijuegoMario;
    public GameObject minijuegoHugo;


    public GameObject edificiosMal;
    public GameObject edificiosMal2;
    public GameObject edificiosBien;
    public GameObject bolsasBasura;
    void Start()
    {

        if (CambioEscenasIslas.previousSceneName == "MinijuegoMonica")
        {
            minijuegoHugo.SetActive(true);
        }
    }

}
