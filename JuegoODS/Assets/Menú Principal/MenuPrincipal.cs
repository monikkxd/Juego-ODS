using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transiciónPrefab;

    private void Start()
    {
        transiciónPrefab.enabled = false;
    }
    public void Jugar()
    {
        transiciónPrefab.enabled = true;
        Invoke("CargarCinemáticaInicial", 2f);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void CargarCinemáticaInicial()
    {
        SceneManager.LoadScene("CinemáticaInicial");
    }

}
