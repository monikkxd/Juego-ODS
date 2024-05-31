using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslaInteractable : MonoBehaviour
{
    public GameObject boolMinijuego1;
    public void CargarMinijuegoNatalia()
    {
        boolMinijuego1.SetActive(true);
        SceneManager.LoadScene("_MontajeEscenaNatalia");
    }
    public void CargarMinijuegoAndrea()
    {
        SceneManager.LoadScene("_MontajeEscenaAndrea");
    }
    public void CargarMinijuegoAlex()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
    public void CargarMinijuegoAlex2()
    {
        SceneManager.LoadScene("MinijuegoAlex2");
    }
    public void CargarMinijuegoHugo()
    {
        SceneManager.LoadScene("MinijuegoHugo");
    }
    public void CargarMinijuegoMonicaG()
    {
        SceneManager.LoadScene("_testmonicag");
    }
    public void CargarMinijuegoMario()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
    public void CargarMinijuegoMigui()
    {
        SceneManager.LoadScene("Minijuego Migui");
    }
    public void CargarMinijuegoClara()
    {
        SceneManager.LoadScene("Minijuego Clara");
    }
}
