using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class CuentaAtrásMario : MonoBehaviour
{
    public float timeRemaining = 60f; // 2 minutos en segundos
    public Text timeText; // Referencia al componente Text de la UI

    private bool timerIsRunning = false;
    public GameObject hasGanado;

    public CharacterController playerController;
    public FirstPersonController firstPersonController;

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
                SelectorNivel.marioCompletado = true;
                playerController.enabled = false;
                firstPersonController.enabled = false;
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimeText(timeRemaining);
                Time.timeScale = 0;
                hasGanado.SetActive(true);
                Invoke("CargarEscena", 2.5f);
                
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
}
