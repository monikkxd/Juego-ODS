using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslaInteractable : MonoBehaviour
{
    public GameObject boolMinijuego1;
    public GameObject boolMinijuego2;
    public void CargarMinijuegoNatalia()
    {
        boolMinijuego1.SetActive(true);
        SceneManager.LoadScene("Lobby Minijuegos Clara");
    }
    public void CargarMinijuegoAndrea()
    {
        boolMinijuego2.SetActive(true);
        SceneManager.LoadScene("MinijuegoAndrea");
    }
    public void CargarMinijuegoAlex()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
}
