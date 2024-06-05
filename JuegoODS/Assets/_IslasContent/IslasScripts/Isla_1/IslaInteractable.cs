using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslaInteractable : MonoBehaviour
{
    public GameObject boolMinijuego1;

    public GameObject transici�n;
    public void CargarMinijuegoNatalia()
    {
        boolMinijuego1.SetActive(true);
        Invoke("CagarNatalia", 2.5f);
    }
    public void CargarMinijuegoAndrea()
    {
        transici�n.SetActive(true);
        Invoke("CargarAndrea", 2.5f);
    }
    public void CargarMinijuegoAlex()
    {
        transici�n.SetActive(true);
        Invoke("CagarAlex", 2.5f);
    }
    public void CargarMinijuegoAlex2()
    {
        transici�n.SetActive(true);
        Invoke("CagarAlex2", 2.5f);
    }
    public void CargarMinijuegoHugo()
    {
        transici�n.SetActive(true);
        Invoke("CagarHugo", 2.5f);
    }
    public void CargarMinijuegoMonicaG()
    {
        transici�n.SetActive(true);
        Invoke("CagarM�nicaG", 2.5f);
    }
    public void CargarMinijuegoMario()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
    public void CargarMinijuegoMigui()
    {
        transici�n.SetActive(true);
        Invoke("CagarMigui", 2.5f);
    }
    public void CargarMinijuegoClara()
    {
        transici�n.SetActive(true);
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

    }
    void CagarAlex()
    {
        SceneManager.LoadScene("MinijuegoAlex");
    }
    void CagarAlex2()
    {
        SceneManager.LoadScene("MinijuegoAlex2");
    }
    
    void CagarM�nicaG()
    {
        SceneManager.LoadScene("_testmonicag");
    }
    void CagarNatalia()
    {
        SceneManager.LoadScene("_MontajeEscenaNatalia");
    }
    void CagarClara()
    {
        SceneManager.LoadScene("MinigameSelectionClara");
    }
    void CargarAndrea()
    {
        SceneManager.LoadScene("_MontajeEscenaAndrea");
    }
    
}
