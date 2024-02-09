using System;
using System.Collections;
using UnityEngine;

public class Mover_Vehículos : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public Vector3 direccionMovimiento = Vector3.right;

    private bool movimientoActivado = false;
    private Vector3 posicionInicial;
    private Vector3 posicionActual; // Nueva variable para almacenar la posición actual

    private bool corutinaActivada = false;

    public GameObject activador;

    

    void Start()
    {
        posicionInicial = transform.position;
        posicionActual = transform.position; 
    }

    private void Update()
    {
        if (activador.gameObject.activeSelf)
        {
            ActivarCorutina();
        }
    }

    public IEnumerator MoverObjetoLerp()
    {
        movimientoActivado = true;

        float tiempoInicio = Time.time;
        float tiempoPasado = 0f;

        while (tiempoPasado < 1f)
        {
            tiempoPasado = (Time.time - tiempoInicio) * velocidadMovimiento;
            transform.position = Vector3.Lerp(posicionActual, posicionActual + direccionMovimiento, tiempoPasado);

            yield return null;
        }

        movimientoActivado = false;
        // Desactivar el script una vez que se completa la condición
        enabled = false;

        yield return null;
    }

    public void ActivarCorutina()
    {
        if (!corutinaActivada)
        {
            // Actualiza la posición actual antes de iniciar la corutina
            posicionActual = transform.position;
            StartCoroutine(MoverObjetoLerp());
            corutinaActivada = true;

            return;
        }

        return;
    }
}
