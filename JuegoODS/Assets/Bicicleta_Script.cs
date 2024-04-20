using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bicicleta_Script : MonoBehaviour
{
    private Animator animator; // Referencia al componente Animator

    void Start()
    {
        // Obtener el componente Animator del objeto actual
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Comprobar las teclas y activar los par�metros de animaci�n
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Activar el par�metro de la animaci�n "A"
            animator.SetBool("PlayA", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Activar el par�metro de la animaci�n "S"
            animator.SetBool("PlayS", true);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            // Activar el par�metro de la animaci�n "J"
            animator.SetBool("PlayJ", true);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            // Activar el par�metro de la animaci�n "K"
            animator.SetBool("PlayK", true);
        }
    }
}
