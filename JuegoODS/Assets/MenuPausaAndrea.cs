using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaAndrea : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject UIMenu;
    public bool CursorVisible = true;

    public bool enMenuPrincipal;

    public WaterHose WaterHose;
    public CameraController CameraController;

    void Start()
    {
        UIMenu.SetActive(false);

        if (enMenuPrincipal)
        {
            Cursor.visible = true;
        }
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CursorVisible == true)
            {
                CursorVisible = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                CursorVisible = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void Resume()
    {

        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
        CursorVisible = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Pause()
    {
        UIMenu.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
        CursorVisible = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SelectorNivel()
    {
        SceneManager.LoadScene("SelecciónNivel");
        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
        CursorVisible = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
        CursorVisible = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
