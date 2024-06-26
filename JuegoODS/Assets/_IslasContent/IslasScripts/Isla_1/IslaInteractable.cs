using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslaInteractable : MonoBehaviour
{
    public GameObject boolMinijuego1;

    public GameObject transición;
    public void CargarMinijuegoNatalia()
    {
        boolMinijuego1.SetActive(true);
        Invoke("CagarNatalia", 2.5f);
    }
    public void CargarMinijuegoAndrea()
    {
        transición.SetActive(true);
        Invoke("CargarAndrea", 2.5f);
    }
    public void CargarMinijuegoAlex()
    {
        transición.SetActive(true);
        Invoke("CagarAlex", 2.5f);
    }
    public void CargarMinijuegoAlex2()
    {
        transición.SetActive(true);
        Invoke("CagarAlex2", 2.5f);
    }
    public void CargarMinijuegoHugo()
    {
        transición.SetActive(true);
        Invoke("CagarHugo", 2.5f);
    }
    public void CargarMinijuegoMonicaG()
    {
        transición.SetActive(true);
        Invoke("CagarMónicaG", 2.5f);
    }
    public void CargarMinijuegoMario()
    {
        transición.SetActive(true);
        Invoke("CargarMario", 2.5f);
    }
    public void CargarMinijuegoMigui()
    {
        transición.SetActive(true);
        Invoke("CagarMigui", 2.5f);
    }
    public void CargarMinijuegoMoni()
    {
        transición.SetActive(true);
        Invoke("CagarMoni", 2.5f);
    }
    public void CargarMinijuegoClara()
    {
        transición.SetActive(true);
        Invoke("CagarClara", 2.5f);
    }

    void CagarMigui()
    {
        SceneManager.LoadScene("Minijuego Migui");
    }
    void CagarHugo()
    {
        SceneManager.LoadScene("MinijuegoHugo");
    }
    void CagarMoni()
    {
        SceneManager.LoadScene("MinijuegoMónicaQ");
    }
    void CagarAlex()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
    void CagarAlex2()
    {
        SceneManager.LoadScene("MinijuegoAlex2");
    }
    
    void CagarMónicaG()
    {
        SceneManager.LoadScene("_testmonicag");
    }
    void CagarNatalia()
    {
        SceneManager.LoadScene("_MontajeEscenaNatalia");
    }
    void CagarClara()
    {
        SceneManager.LoadScene("Lobby Minijuegos Clara");
    }
    void CargarAndrea()
    {
        SceneManager.LoadScene("_MontajeEscenaAndrea");
    }

    void CargarMario()
    {
        SceneManager.LoadScene("_MontajeEscenaMario");
    }
    
}
