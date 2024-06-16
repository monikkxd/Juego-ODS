using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject UIMenu;

    void Start()
    {
        UIMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    public void Pause()
    {
        UIMenu.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }

    public void SelectorNivel()
    {
        SceneManager.LoadScene("SelecciónNivel");
        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
