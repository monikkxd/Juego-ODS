using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transici�nPrefab;

    private void Start()
    {
        transici�nPrefab.enabled = false;
    }
    public void Jugar()
    {
        transici�nPrefab.enabled = true;
        Invoke("CargarCinem�ticaInicial", 2f);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void CargarCinem�ticaInicial()
    {
        SceneManager.LoadScene("Cinem�ticaInicial");
    }

}
