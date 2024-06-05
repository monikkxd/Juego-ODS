using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject transición1;
    public GameObject transición2;

    private void LoadLevel1Clara()
    {
        SceneManager.LoadScene("Minijuego Clara");
    }

    private void LoadLevel2Clara()
    {
        SceneManager.LoadScene("Minijuego Clara 2");
    }

    private void LoadLevel3Clara()
    {
        Debug.Log("Falta por asignar una escena");
    }

    public void CargarMinijuego1()
    {
        transición1.SetActive(true);
        Invoke("LoadLevel1Clara", 2f);
    }
    public void CargarMinijuego2()
    {
        transición2.SetActive(true);
        Invoke("LoadLevel2Clara", 2f);
    }
}
