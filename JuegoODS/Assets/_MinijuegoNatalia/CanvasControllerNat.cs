using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControllerNat : MonoBehaviour
{
    public RectTransform subMenu; // Una referencia al RectTransform del submen� en el Canvas.
    float posFinal; // La posici�n final a la que se mover� el submen�.
    bool abrirMenu = true; // Un indicador para saber si el men� est� abierto o cerrado.
    public float tiempo = 0.5f; // El tiempo que tomar� la animaci�n de movimiento.

    public GameObject tuto;

    public GameObject pagina2;
    public GameObject pagina3;
    public GameObject pagina4;

    //public CuentaAtrasTemporal CuentaAtrasTemporal;

    void Start()
    {
        //CuentaAtrasTemporal.enabled = false;
        // El c�digo en el m�todo Start se ejecuta una vez al inicio del script.
        posFinal = Screen.width / 2; // Se calcula la posici�n final como la mitad del ancho de la pantalla.
        subMenu.position = new Vector3(-posFinal, subMenu.position.y, 0); // Se coloca el submen� fuera de la pantalla al inicio.

        Invoke("ActivarCuentaAtr�s", 7f);
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
        float elapsedTime = 0; // El tiempo que ha transcurrido durante la animaci�n.

        while (elapsedTime < time)
        {
            subMenu.position = Vector3.Lerp(posInit, posFin, (elapsedTime / time)); // Se mueve el submen� gradualmente entre las posiciones inicial y final.
            elapsedTime += Time.deltaTime; // Se actualiza el tiempo transcurrido.
            yield return null; // Se espera al siguiente frame antes de continuar.
        }

        subMenu.position = posFin; // Asegura que la posici�n final sea exacta al final de la animaci�n.
    }

    void MoverMenu(float time, Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(Mover(time, posInit, posFin)); // Inicia la animaci�n de movimiento del submen�.
    }

    public void BUTTON_Sub_Menu()
    {
        int signo = 1; // Variable que determina si el men� se abrir� o cerrar�.

        if (!abrirMenu)
            signo = -1;

        MoverMenu(tiempo, subMenu.position, new Vector3(signo * posFinal, subMenu.position.y, 0)); // Llama al m�todo para mover el men�.
        abrirMenu = !abrirMenu; // Cambia el estado del indicador de men� abierto/cerrado.
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

    public void ActivarCuentaAtr�s()
    {
        //CuentaAtrasTemporal.enabled = true;
    }
}
