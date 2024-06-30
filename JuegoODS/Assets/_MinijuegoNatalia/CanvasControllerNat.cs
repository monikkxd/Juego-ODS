using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControllerNat : MonoBehaviour
{
    public RectTransform subMenu; // Una referencia al RectTransform del submenú en el Canvas.
    float posFinal; // La posición final a la que se moverá el submenú.
    bool abrirMenu = true; // Un indicador para saber si el menú está abierto o cerrado.
    public float tiempo = 0.5f; // El tiempo que tomará la animación de movimiento.

    public GameObject tuto;

    public GameObject pagina2;
    public GameObject pagina3;
    public GameObject pagina4;

    //public CuentaAtrasTemporal CuentaAtrasTemporal;

    void Start()
    {
        //CuentaAtrasTemporal.enabled = false;
        // El código en el método Start se ejecuta una vez al inicio del script.
        posFinal = Screen.width / 2; // Se calcula la posición final como la mitad del ancho de la pantalla.
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0); // Se coloca el submenú fuera de la pantalla al inicio.

        Invoke("ActivarCuentaAtrás", 7f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            BUTTON_Sub_Menu();
        }
    }

    IEnumerator Mover(float time, Vector3 posInit, Vector3 posFin)
    {
        float elapsedTime = 0; // El tiempo que ha transcurrido durante la animación.

        while (elapsedTime < time)
        {
            subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time)); // Se mueve el submenú gradualmente entre las posiciones inicial y final.
            elapsedTime += Time.deltaTime; // Se actualiza el tiempo transcurrido.
            yield return null; // Se espera al siguiente frame antes de continuar.
        }

        subMenu.position = posFin; // Asegura que la posición final sea exacta al final de la animación.
    }

    void MoverMenu(float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(Mover(time, posInit, posFin)); // Inicia la animación de movimiento del submenú.
    }

    public void BUTTON_Sub_Menu()
    {
        int signo = 1; // Variable que determina si el menú se abrirá o cerrará.

        if (!abrirMenu)
            signo = -1;

        MoverMenu(tiempo, subMenu.position, new Vector3(signo * posFinal, subMenu.position.y, 0)); // Llama al método para mover el menú.
        abrirMenu = !abrirMenu; // Cambia el estado del indicador de menú abierto/cerrado.
    }

    public void Siguientepagina1()
    {
        pagina2.SetActive(true);
    }

    public void Atraspagina2()
    {
        pagina2.SetActive(false);
    }

    public void Siguientepagina2()
    {
        pagina3.SetActive(true);
    }

    public void Atraspagina3()
    {
        pagina3.SetActive(false);
    }

    public void Siguientepagina3()
    {
        pagina4.SetActive(true);
    }

    public void Atraspagina4()
    {
        pagina4.SetActive(false);
    }

    public void ActivarCuentaAtrás()
    {
        //CuentaAtrasTemporal.enabled = true;
    }
}
