using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject UIMenu;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float mouseSensitivity = 1.0f;

    private Vector2 cursorHostpot;

    private bool menúAbierto = false;
    void Start()
    {
        UIMenu.SetActive(false);
        cursorHostpot = new Vector2(cursorTexture.width, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHostpot, CursorMode.Auto);

        Cursor.visible = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menúAbierto = false;
            Cursor.visible = true;
            if (menúAbierto == false)
            {
                Cursor.visible = true;
                menúAbierto = true;

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
       
       
    }

    public void Resume()
    {
        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
        Cursor.visible = false;
    }

    public void Pause()
    {
        UIMenu.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
        Cursor.visible = true;
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
        Application.Quit();
    }

    public void AbrirMenú()
    {
        UIMenu.SetActive(true);
    }
}
