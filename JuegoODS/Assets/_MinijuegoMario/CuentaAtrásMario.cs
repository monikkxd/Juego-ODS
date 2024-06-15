using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtrásMario : MonoBehaviour
{
    public float timeRemaining = 60f; // 2 minutos en segundos
    public Text timeText; // Referencia al componente Text de la UI

    private bool timerIsRunning = false;
    public GameObject hasGanado;

    void Start()
    {
        timerIsRunning = true;
        hasGanado.SetActive(false);
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
                Time.timeScale = 0;
                hasGanado.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("CargoEscena");
                    //Invoke("CargarEscena", 1f);
                }
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
        SceneManager.LoadScene("SegundaIsla3");
    }
}
