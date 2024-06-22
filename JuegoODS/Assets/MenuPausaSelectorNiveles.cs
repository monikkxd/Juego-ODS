using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaSelectorNiveles : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject UIMenu;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float mouseSensitivity = 1.0f;

    private Vector2 cursorHostpot;


    void Start()
    {
        UIMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.None;

        if (SelectorNivel.andreaCompletado == true)
        {
            Cursor.visible = true;
            Debug.Log("Andrea Completado");
        }
        else
        {
            cursorHostpot = new Vector2(cursorTexture.width, cursorTexture.height / 2);
            Cursor.SetCursor(cursorTexture, cursorHostpot, CursorMode.Auto);
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
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
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
