using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerIsla3 : MonoBehaviour
{
    public GameObject minijuegoClara;
    public GameObject minijuegoMigui;

    void Start()
    {
        if (CambioEscenasIslas.previousSceneName == "Minijuego Clara 2")
        {
            minijuegoMigui.SetActive(true);
        }
    }

}
