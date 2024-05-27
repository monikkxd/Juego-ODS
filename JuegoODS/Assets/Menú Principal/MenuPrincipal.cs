using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject transiciónPrefab;
    public void Jugar()
    {
        transiciónPrefab.SetActive(true);
        Invoke("CargarPrimeraIsla", 2f);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void CargarPrimeraIsla()
    {
        SceneManager.LoadScene("PrimeraIsla");
    }

}
