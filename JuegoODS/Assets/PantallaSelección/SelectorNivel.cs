using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorNivel : MonoBehaviour
{
    public GameObject transici�n;
   public void JuegoAlex()
   {
        transici�n.SetActive(true);
        Invoke("CargarAlex", 2.5f);
   }

    public void JuegoMoni()
    {
        transici�n.SetActive(true);
        Invoke("CargarMoni", 2.5f);
    }

    public void JuegoHugo()
    {
        transici�n.SetActive(true);
        Invoke("CargarHugo", 2.5f);
    }

    public void JuegoAndrea()
    {
        transici�n.SetActive(true);
        Invoke("CargarAndrea", 2.5f);
    }

    public void JuegoNatalia()
    {
        transici�n.SetActive(true);
        Invoke("CargarNatalia", 2.5f);
    }

    public void JuegoMario()
    {
        transici�n.SetActive(true);
        Invoke("CargarMario", 2.5f);
    }

    public void JuegoMigui()
    {
        transici�n.SetActive(true);
        Invoke("CargarMigui", 2.5f);
    }

    public void JuegoMonica()
    {
        transici�n.SetActive(true);
        Invoke("CargarMonicaG", 2.5f);
    }

    public void JuegoClara()
    {
        transici�n.SetActive(true);
        Invoke("CargarClara", 2.5f);
    }

    void CargarAlex()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
    void CargarMoni()
    {
        SceneManager.LoadScene("MinijuegoM�nicaQ");
    }
    void CargarAndrea()
    {
        SceneManager.LoadScene("_MontajeEscenaAndrea");
    }
    void CargarMigui()
    {
        SceneManager.LoadScene("Minijuego Migui");
    }
    void CargarNatalia()
    {
        SceneManager.LoadScene("_MontajeEscenaNatalia");
    }
    void CargarClara()
    {
        SceneManager.LoadScene("Lobby Minijuegos Clara");
    }
    void CargarHugo()
    {
        SceneManager.LoadScene("MinijuegoHugo");
    }
    void CargarMario()
    {
        SceneManager.LoadScene("_MontajeEscenaMario");
    }
    void CargarMonicaG()
    {
        SceneManager.LoadScene("_testmonicag");
    }
}
