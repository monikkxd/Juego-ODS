using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    public GameObject transici�n;
    public void ElegirCanci�n()
    {
        SceneManager.LoadScene("SeleccionCancion");
    }

    public void PlayBoulevar()
    {
        SceneManager.LoadScene("Boulevar");
    }

    public void FinishBoulevar()
    {
        SceneManager.LoadScene("TerceraIsla");
    }
    public void FinishBoulevar2()
    {
        SceneManager.LoadScene("SegundaIsla");
    }
    public void Cargarisla2()
    {
        transici�n.SetActive(true);
        Invoke("FinishBoulevar2", 2.5f);
    }
    public void Cargarisla3()
    {
        transici�n.SetActive(true);
        Invoke("FinishBoulevar", 2.5f);
    }

    
}
