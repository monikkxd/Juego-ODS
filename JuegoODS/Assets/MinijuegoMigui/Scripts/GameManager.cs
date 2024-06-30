using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    private List<string> tiposDePlatoDisponibles = new List<string>();

    public int numerosPedidos = 0;

    public TMP_Text numeroPedidosText;

    public GameObject winAnimationTransiction;
    public GameObject diálogoFinal;
    public GameObject HUD;

    public TMP_Text timerText; 
    private float timeRemaining = 60f;
    private bool timerIsRunning = false;

    public GameObject tiempo;
    public GameObject clientes;
    public GameObject cocineros;
    public GameObject tuto;
    public GameObject cámaraBarra;
    public GameObject dinero;
    public GameObject dinero2;

    public GameObject textoDerrota;
    public GameObject fadeIn;

    void Start()
    {
        cámaraBarra.SetActive(false);
        dinero.SetActive(false);
        dinero2.SetActive(false);

        Invoke("ComenzarMinijuego", 6f);
        Invoke("ActivarTuto", 1f);


        StartCoroutine(IniciarTimer());

        numeroPedidosText.text = numerosPedidos.ToString();
        Plato_Class[] platosEnEscena = FindObjectsOfType<Plato_Class>();

        foreach (var plato in platosEnEscena)
        {
            string tipoPlato = ObtenerTipoPlato(plato);
            if (!tiposDePlatoDisponibles.Contains(tipoPlato))
            {
                tiposDePlatoDisponibles.Add(tipoPlato);
            }
        }
    }

    private void Update()
    {
        numeroPedidosText.text = numerosPedidos.ToString() + " / 200";

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timeRemaining = Mathf.Clamp(timeRemaining, 0, Mathf.Infinity);
                UpdateTimerText();
            }
            else if (numerosPedidos >= 180)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                HUD.SetActive(false);
                diálogoFinal.SetActive(true);
                Invoke("ActivarTransición", 7.5f);
                Invoke("CargarCallejónMigui", 10.5f);
                UpdateTimerText();
                Debug.Log("Time has run out!");
            }
            else if(numerosPedidos <= 179)
            {
                StartCoroutine(SecuenciaDerrota());
            }
        }
    }


    private string ObtenerTipoPlato(Plato_Class plato)
    {
        // Determinar el tipo de plato basado en el componente del plato
        if (plato is Plato_1)
        {
            return "Plato1";
        }
        else if (plato is Plato_2)
        {
            return "Plato2";
        }
        else if (plato is Plato_3)
        {
            return "Plato3";
        }
        else
        {
            return "Desconocido";
        }
    }

    public string ObtenerPedidoAleatorio()
    {
        // Seleccionar aleatoriamente un tipo de plato disponible como pedido
        if (tiposDePlatoDisponibles.Count > 0)
        {
            return tiposDePlatoDisponibles[Random.Range(0, tiposDePlatoDisponibles.Count)];
        }
        else
        {
            return "PlatoDefault"; // Si no hay platos disponibles, se devuelve un pedido genérico
        }
    }

    public void SumarDinero()
    {
        numerosPedidos += Random.Range(60, 75); 
    }

    public void RestarDinero()
    {
        numerosPedidos -= 25;
    }

    private void UpdateTimerText()
    {
        // Formatea el tiempo restante en minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CargarCallejónMigui()
    {
        SceneManager.LoadScene("CallejónMigui");
    }

    public void ActivarTransición()
    {
        winAnimationTransiction.SetActive(true);

    }

    void ComenzarMinijuego()
    {
        tiempo.SetActive(true);
        clientes.SetActive(true);
        cocineros.SetActive(true);
        tuto.SetActive(false);
        cámaraBarra.SetActive(true);
        dinero.SetActive(true);
        dinero2.SetActive(true);
    }

    IEnumerator SecuenciaDerrota()
    {
        textoDerrota.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        fadeIn.SetActive(true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("SelecciónNivel");
    }

    void ActivarTuto()
    {
        tuto.SetActive(true);
    }

    IEnumerator IniciarTimer()
    {
        yield return new WaitForSeconds(6);

        timerIsRunning = true;
    }
}
