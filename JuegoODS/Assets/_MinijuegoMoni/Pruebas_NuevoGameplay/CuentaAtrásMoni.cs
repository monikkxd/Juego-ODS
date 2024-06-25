using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtrásMoni : MonoBehaviour
{
    public float timeRemaining = 120f; 
    public TMP_Text timeText; 

    private bool timerIsRunning = false;

    public GameObject transición;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimeText(timeRemaining);
            }
            else
            {
                SelectorNivel.monicaCompletado = true;
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
        currentTime += 1; 
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

