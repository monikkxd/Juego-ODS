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
    public Button botónMoni;
    public Button botónAlex;
    public Button botónAndrea;
    public Button botónMonica;
    public Button botónMigui;
    public Button botónMario;
    public Button botónNatalia;
    public Button botónClara;

    [Header("Indicadores Juegos Completados")]
    public GameObject hugoCompletadoObject;
    public GameObject moniCompletadoObject;
    public GameObject alexCompletadoObject;
    public GameObject andreaCompletadoObject;
    public GameObject miguiCompletadoObject;
    public GameObject marioCompletadoObject;
    public GameObject nataliaCompletadoObject;
    public GameObject claraCompletadoObject;
    public GameObject monicaCompletadoObject;

    public static bool hugoCompletado = false;
    public static bool nataliaCompletado = false;
    public static bool MoniCompletado = false;
    public static bool AlexCompletado = false;
    public static bool andreaCompletado = false;
    public static bool miguiCompletado = false;
    public static bool marioCompletado = false;
    public static bool monicaCompletado = false;
    public static bool claraCompletado = false;

    [Header("Transición Final")]
    public GameObject transiciónFinal;


    private void Start()
    {
        hugoCompletadoObject.SetActive(false);
        moniCompletadoObject.SetActive(false);
        alexCompletadoObject.SetActive(false);
        andreaCompletadoObject.SetActive(false);
        miguiCompletadoObject.SetActive(false);
        marioCompletadoObject.SetActive(false);
        nataliaCompletadoObject.SetActive(false);
        claraCompletadoObject.SetActive(false);
        monicaCompletadoObject.SetActive(false);
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
        if (hugoCompletado == true)
        {
            hugoCompletadoObject.SetActive(true);
            botónHugo.enabled = false;
        }
        if(monicaCompletado == true)
        {
            monicaCompletadoObject.SetActive(true);
            botónMonica.enabled = false;
        }
        if (MoniCompletado == true)
        {
            moniCompletadoObject.SetActive(true);
            botónMoni.enabled = false;
        }
        if (miguiCompletado == true)
        {
            miguiCompletadoObject.SetActive(true);
            botónMigui.enabled = false;
        }
        if (claraCompletado == true)
        {
            claraCompletadoObject.SetActive(true);
            botónClara.enabled = false;
        }
        if (marioCompletado == true)
        {
            marioCompletadoObject.SetActive(true);
            botónMario.enabled = false;
        }
        if (nataliaCompletado == true)
        {
            nataliaCompletadoObject.SetActive(true);
            botónNatalia.enabled = false;
        }
        if (AlexCompletado == true)
        {
            alexCompletadoObject.SetActive(true);
            botónAlex.enabled = false;
        }
        if (andreaCompletado == true)
        {
            andreaCompletadoObject.SetActive(true);
            botónAndrea.enabled = false;
        }

        if(AlexCompletado && andreaCompletado && monicaCompletado && MoniCompletado && miguiCompletado && nataliaCompletado && hugoCompletado && claraCompletado && marioCompletado)
        {
            StartCoroutine(CargarVictoria());
        }
    }

    IEnumerator CargarVictoria()
    {
        yield return new WaitForSeconds(3f);

        transiciónFinal.SetActive(true);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("EscenaFinal");
    }

}
