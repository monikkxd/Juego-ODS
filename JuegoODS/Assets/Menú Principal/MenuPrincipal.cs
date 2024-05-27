using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject transici�nPrefab;
    public void Jugar()
    {
        transici�nPrefab.SetActive(true);
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
