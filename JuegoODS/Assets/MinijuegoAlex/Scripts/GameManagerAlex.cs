using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerAlex : MonoBehaviour
{
    public AudioSource Musica;

    public bool Empezarmusica;

    public BeatScroller bs;

    public static GameManagerAlex instance;

    public GameObject PressButtonStart;

    public int PuntosActuales;
    private int PuntosPorNota = 100;
    private int PuntosNotaGood = 125;
    private int PuntosNotaPerfe = 150;

    public int MultiActual;
    public int MultiplierTracker;
    public int[] MultiArchivador;

    public Text PuntosTexto;
    public Text MultiText;

    public float TotalFichas;
    public float NormalFichas;
    public float GoodFichas;
    public float PerfeFichas;
    public float MissFichas;

    public GameObject VentanaResultados;
    public Text PorcentajeText, HitText, GoodText, PerfeText, MissedText, RankText, PuntuacionFinalText;

    public BarraPuntuaciónScritp barraPuntuaciónScritp;

    public Slider barraProgresionSlider;
    private float tiempoTotal = 140f;
    private float tiempoTranscurrido = 0f;

    private bool juegoEmpezado = false;

    public GameObject bateríaCargada;
    public GameObject tuto;
    public GameObject imagenFlor;

    public int PuntuaciónMínima;

    public string EscenaSiguiente;

    private bool ResultadosActivados = true;
    void Start()
    {
        instance = this;

        PuntosActuales = 0;
        MultiActual = 1;
        PuntosTexto.text = "Puntuación: 0";

        TotalFichas = FindObjectsOfType<FichasObject>().Length;
        barraPuntuaciónScritp.SetMaxValueSlider(60000);

        barraProgresionSlider.value = 0;
        barraProgresionSlider.maxValue = 100;
    }


    void Update()
    {

        
        if (juegoEmpezado == true)
        {
            tiempoTranscurrido += Time.deltaTime;
            float valorActual = Mathf.Clamp((tiempoTranscurrido / tiempoTotal) * 100, 0, 100);
            barraProgresionSlider.value = valorActual;
        }
        if (!Empezarmusica)
        {
            
            if (Input.anyKeyDown)
            {
                StartCoroutine(Delay(3));
            }
        }
        else
        {
            if (!Musica.isPlaying && !VentanaResultados.activeInHierarchy && ResultadosActivados)
            {
                SelectorNivel.AlexCompletado = true;
                VentanaResultados.SetActive(true);

                HitText.text = "" + NormalFichas;
                GoodText.text = "" + GoodFichas;
                PerfeText.text = "" + PerfeFichas;
                MissedText.text = "" + MissFichas;

                float TotalHits = NormalFichas + GoodFichas + PerfeFichas;
                float Porcentaje = (TotalHits / TotalFichas) * 100f;

                PorcentajeText.text = Porcentaje.ToString("F1") + "%";

                string RankVal = "F";

                if (Porcentaje < 40)
                {
                    RankVal = "E";
                }
                else if (Porcentaje >= 40 && Porcentaje < 55)
                {
                    RankVal = "D";
                }
                else if (Porcentaje >= 55 && Porcentaje < 70)
                {
                    RankVal = "C";
                }
                else if (Porcentaje >= 70 && Porcentaje < 85)
                {
                    RankVal = "B";
                }
                else if (Porcentaje >= 85 && Porcentaje < 100)
                {
                    RankVal = "A";
                }
                else if (Porcentaje == 100)
                {
                    RankVal = "S";
                }

                RankText.text = RankVal;

                PuntuacionFinalText.text = PuntosActuales.ToString();

                Invoke("FinalDeJuego", 4f);
            }
        }

        if (PuntosActuales >= PuntuaciónMínima)
        {
            bateríaCargada.SetActive(true);
        }
    }

    public void Hitted()
    {

        if (MultiActual - 1 < MultiArchivador.Length)
        {
            MultiplierTracker++;

            if (MultiArchivador[MultiActual - 1] <= MultiplierTracker)
            {
                MultiplierTracker = 0;
                MultiActual++;
            }
        }

        MultiText.text = "Multiplicador: x" + MultiActual;

        PuntosTexto.text = "Puntuación: " + PuntosActuales.ToString();
        barraPuntuaciónScritp.SetValue(PuntosActuales);
    }

    public void NormalHit()
    {
        PuntosActuales += PuntosPorNota * MultiActual;
        Hitted();

        NormalFichas++;
    }

    public void GoodHit()
    {
        PuntosActuales += PuntosNotaGood * MultiActual;
        Hitted();

        GoodFichas++;
    }

    public void PerfeHit()
    {
        PuntosActuales += PuntosNotaPerfe * MultiActual;
        Hitted();

        PerfeFichas++;
    }

    public void Missed()
    {
        MultiActual = 1;

        MultiplierTracker = 0;

        MultiText.text = "Multiplicador: x" + MultiActual;

        MissFichas++;
    }

    void FinalDeJuego()
    {
        tuto.SetActive(true);
        ResultadosActivados = false;
        VentanaResultados.SetActive(false);
        Invoke("ActivarFlor", 4f);
    }
    void ActivarFlor()
    {
        imagenFlor.SetActive(true);
        Invoke("CambioEscena", 2f);
    }

    void CambioEscena()
    {
        SceneManager.LoadScene(EscenaSiguiente);
    }

    IEnumerator Delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(PressButtonStart);
        Empezarmusica = true;
        juegoEmpezado = true;
        bs.StartGame = true;

        Musica.Play();
    }
}