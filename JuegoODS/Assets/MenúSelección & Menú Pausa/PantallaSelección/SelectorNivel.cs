using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectorNivel : MonoBehaviour
{
    [Header("Transiciones")]
    public GameObject transición, transición2, transición3, transición4;

    [Header("Botones Minijuegos")]
    public Button botónHugo;

    [Header("Indicadores Juegos Completados")]
    public GameObject hugoCompletadoObject;

    public static bool hugoCompletado = false;


    private void Start()
    {
        hugoCompletadoObject.SetActive(false);
    }
    public void JuegoAlex()
    {
        transición.SetActive(true);
        Invoke("CargarAlex", 2.5f);
    }

    public void JuegoMoni()
    {
        transición4.SetActive(true);
        Invoke("CargarMoni", 2.5f);
    }

    public void JuegoHugo()
    {
        transición.SetActive(true);
        Invoke("CargarHugo", 2.5f);
    }

    public void JuegoAndrea()
    {
        transición.SetActive(true);
        Invoke("CargarAndrea", 2.5f);
    }

    public void JuegoNatalia()
    {
        transición3.SetActive(true);
        Invoke("CargarNatalia", 2.5f);
    }

    public void JuegoMario()
    {
        transición.SetActive(true);
        Invoke("CargarMario", 2.5f);
    }

    public void JuegoMigui()
    {
        transición.SetActive(true);
        Invoke("CargarMigui", 2.5f);
    }

    public void JuegoMonica()
    {
        transición.SetActive(true);
        Invoke("CargarMonicaG", 2.5f);
    }

    public void JuegoClara()
    {
        transición.SetActive(true);
        Invoke("CargarClara", 2.5f);
    }

    void CargarAlex()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
    void CargarMoni()
    {
        SceneManager.LoadScene("MinijuegoMónicaQ");
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
            botónHugo.enabled = false;
        }
    }

}
