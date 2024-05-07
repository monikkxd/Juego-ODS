using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenasIslas : MonoBehaviour
{
    public static string previousSceneName = "";


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            LoadScene("");
        }
    }
    public void LoadScene(string sceneName)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
