using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transici�nPrefab;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float mouseSensitivity = 1.0f;

    private Vector2 cursorHostpot;
    private void Start()
    {
        transici�nPrefab.enabled = false;

        cursorHostpot = new Vector2(cursorTexture.width, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHostpot, CursorMode.Auto);

        Cursor.visible = true;
    }
    public void Jugar()
    {
        transici�nPrefab.enabled = true;
        Invoke("CargarCinem�ticaInicial", 2f);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void CargarCinem�ticaInicial()
    {
        SceneManager.LoadScene("Cinem�ticaInicial");
    }

}
