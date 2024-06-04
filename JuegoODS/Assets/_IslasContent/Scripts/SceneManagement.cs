using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadLevel1Clara()
    {
        SceneManager.LoadScene("Minijuego Clara");
    }

    public void LoadLevel2Clara()
    {
        SceneManager.LoadScene("Minijuego Clara 2");
    }

    public void LoadLevel3Clara()
    {
        Debug.Log("Falta por asignar una escena");
    }


}
