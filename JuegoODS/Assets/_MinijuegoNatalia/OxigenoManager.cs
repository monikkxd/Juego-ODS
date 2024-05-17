using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxigenoManager : MonoBehaviour
{
    public Slider barraOxigeno;
    public float decrementoVelocidad = 5f;
    public float incrementoVelocidad = 10f; 
    public float oxigenoMaximo = 100f;

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
            oxigenoActual = Mathf.Clamp(oxigenoActual, 0, oxigenoMaximo);  // Asegura que no pase del m�ximo
        }

        barraOxigeno.value = oxigenoActual;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Oxigeno"))
        {
            estaEnOxigeno = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Oxigeno"))
        {
            estaEnOxigeno = false;
        }
    }
}
