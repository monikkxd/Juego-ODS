using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class MenuPausaAlex : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject UIMenu;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float mouseSensitivity = 1.0f;

    private Vector2 cursorHostpot;

    private bool men�Abierto = false;

    public AudioSource source;
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
            source.Pause();
            men�Abierto = false;
            if (men�Abierto == false)
            {
                Cursor.visible = true;
                men�Abierto = true;

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
        source.Play();
        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
        Cursor.visible = true;
    }

    public void Pause()
    {
        source.Pause();
        UIMenu.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
        Cursor.visible = false;
    }

    public void SelectorNivel()
    {
        SceneManager.LoadScene("Selecci�nNivel");
        UIMenu.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void AbrirMen�()
    {
        UIMenu.SetActive(true);
    }

}