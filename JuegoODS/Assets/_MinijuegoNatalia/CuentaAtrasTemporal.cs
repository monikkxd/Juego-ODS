using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtrasTemporal : MonoBehaviour
{
    public float timeRemaining = 120f; // 2 minutos en segundos
    public Text timeText; // Referencia al componente Text de la UI

    private bool timerIsRunning = false;

    public GameObject transición;

    void Update()
    {
        if (timerIsRunning==true)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimeText(timeRemaining);
            }
            else
            {
                SelectorNivel.nataliaCompletado = true;
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimeText(timeRemaining);

                transición.SetActive(true); 
                Invoke("CargarEscena", 2f);

            }
        }
    }

    void UpdateTimeText(float currentTime)
    {
        currentTime += 1; // Ajuste para mostrar correctamente el tiempo restante
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CargarEscena()
    {
        SceneManager.LoadScene("SelecciónNivel");
    }

    public void ActivarTimer()
    {
        timerIsRunning = true;
    }
}

