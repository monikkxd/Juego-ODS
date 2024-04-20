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
        // Comprobar las teclas y activar los parámetros de animación
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Activar el parámetro de la animación "A"
            animator.SetBool("PlayA", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Activar el parámetro de la animación "S"
            animator.SetBool("PlayS", true);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            // Activar el parámetro de la animación "J"
            animator.SetBool("PlayJ", true);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            // Activar el parámetro de la animación "K"
            animator.SetBool("PlayK", true);
        }
    }
}
