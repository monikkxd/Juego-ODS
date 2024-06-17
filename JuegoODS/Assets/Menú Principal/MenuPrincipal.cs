using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transiciónPrefab;

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float mouseSensitivity = 1.0f;

    private Vector2 cursorHostpot;
    private void Start()
    {
        transiciónPrefab.enabled = false;

        cursorHostpot = new Vector2(cursorTexture.width, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHostpot, CursorMode.Auto);

        Cursor.visible = true;
    }
    public void Jugar()
    {
        transiciónPrefab.enabled = true;
        Invoke("CargarCinemáticaInicial", 2f);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void CargarCinemáticaInicial()
    {
        SceneManager.LoadScene("CinemáticaInicial");
    }

}
