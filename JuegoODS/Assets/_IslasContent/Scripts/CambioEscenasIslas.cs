using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenasIslas : MonoBehaviour
{
    public static string previousSceneName = "";

    public string islaACargar;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            LoadScene(islaACargar);
        }
    }
    public void LoadScene(string sceneName)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
