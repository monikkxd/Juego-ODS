using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemáticaManager : MonoBehaviour
{
    public void CargarSelecciónDeNivel()
    {
        SceneManager.LoadScene("SelecciónNivel");
    }
}
