
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

    public GameObject winText;

    public TMP_Text timerText; 
    private float timeRemaining = 60f;
    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;

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
        numeroPedidosText.text = numerosPedidos.ToString();

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timeRemaining = Mathf.Clamp(timeRemaining, 0, Mathf.Infinity);
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                winText.SetActive(true);
                Invoke("CargarIsla3", 2f);
                UpdateTimerText();
                Debug.Log("Time has run out!");
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
        numerosPedidos += 5; 
    }

    public void RestarDinero()
    {
        numerosPedidos -= 3;
    }

    private void UpdateTimerText()
    {
        // Formatea el tiempo restante en minutos y segundos
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CargarIsla3()
    {
        SceneManager.LoadScene("CallejónMigui");
    }
}
