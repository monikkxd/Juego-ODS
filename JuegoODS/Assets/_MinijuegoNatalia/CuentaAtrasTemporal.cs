using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtrasTemporal : MonoBehaviour
{
    public float timeRemaining = 120f; // 2 minutos en segundos
    public Text timeText; // Referencia al componente Text de la UI

    // Referencia a la imagen que queremos activar
    public Image imageToActivate;



    private bool timerIsRunning = false;

    public GameObject transición;

    void Update()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeText(timeRemaining);
        }
        else
        {

            StartCoroutine(ActivateImageRoutine());

            
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

    private IEnumerator ActivateImageRoutine()
    {
        // Activar la imagen
        imageToActivate.gameObject.SetActive(true);

        // Esperar 5 segundos
        yield return new WaitForSeconds(5f);

        SelectorNivel.nataliaCompletado = true;
        Debug.Log("Time has run out!");
        timeRemaining = 0;
        timerIsRunning = false;
        UpdateTimeText(timeRemaining);

        transición.SetActive(true);
        Invoke("CargarEscena", 2f);

        // Aquí puedes agregar la acción que deseas realizar después de los 5 segundos
        Debug.Log("5 segundos han pasado. Puedes realizar otra acción aquí.");
    }
}

