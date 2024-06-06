using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuentaAtrasTemporal : MonoBehaviour
{
    public float timeRemaining = 120f; // 2 minutos en segundos
    public Text timeText; // Referencia al componente Text de la UI

    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimeText(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimeText(timeRemaining);

                //METER AQUÍ EL CAMBIO DE ESCENA.
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
}

