using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaAndrea : MonoBehaviour
{
    public static string previousSceneName = "MinijuegoAndrea";

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            LoadScene("PrimeraIsla");
        }
    }
    public void LoadScene(string sceneName)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
