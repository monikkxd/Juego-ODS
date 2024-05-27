using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
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
}
