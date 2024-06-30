using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OxigenoManager : MonoBehaviour
{
    public Slider barraOxigeno;
    public float decrementoVelocidad = 5f;
    public float incrementoVelocidad = 10f; 
    public float oxigenoMaximo = 20f;

    public GameObject tutoOxigeno;

    private float oxigenoActual;
    private bool estaEnOxigeno = false;

    void Start()
    {
        oxigenoActual = oxigenoMaximo;
        barraOxigeno.maxValue = oxigenoMaximo;
        barraOxigeno.value = oxigenoActual;
    }

    void Update()
    {
        if (!estaEnOxigeno)
        {
            oxigenoActual -= decrementoVelocidad * Time.deltaTime;
        }
        else
        {
            oxigenoActual += incrementoVelocidad * Time.deltaTime;
            oxigenoActual = Mathf.Clamp(oxigenoActual, 0, oxigenoMaximo);  // Asegura que no pase del máximo
        }

        barraOxigeno.value = oxigenoActual;

        if (oxigenoActual <= 0)
        {
            Debug.Log("Te has quedado sin oxígeno");
            SceneManager.LoadScene("SelecciónNivel");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);

        if (collider.name== "Burbuja")
        {
            tutoOxigeno.SetActive(true);
            estaEnOxigeno = true;
            Debug.Log("recuperando oxígeno");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Burbuja")
        {

            tutoOxigeno.SetActive(false);
            estaEnOxigeno = false;
        }
    }
}

