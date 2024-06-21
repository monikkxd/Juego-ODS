using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectorNivel : MonoBehaviour
{
    [Header("Transiciones")]
    public GameObject transici�n, transici�n2, transici�n3, transici�n4;

    [Header("Botones Minijuegos")]
    public Button bot�nHugo;

    [Header("Indicadores Juegos Completados")]
    public GameObject hugoCompletadoObject;

    public static bool hugoCompletado = false;


    private void Start()
    {
        hugoCompletadoObject.SetActive(false);
    }
    public void JuegoAlex()
    {
        transici�n.SetActive(true);
        Invoke("CargarAlex", 2.5f);
    }

    public void JuegoMoni()
    {
        transici�n4.SetActive(true);
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
        transici�n3.SetActive(true);
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

    private void Update()
    {
        if(hugoCompletado == true)
        {
            hugoCompletadoObject.SetActive(true);
            bot�nHugo.enabled = false;
        }
    }

}
