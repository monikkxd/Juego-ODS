using System.Collections;
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
            StartCoroutine(ResetAnimationParameter("PlayA"));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Activar el par�metro de la animaci�n "S"
            animator.SetBool("PlayS", true);
            StartCoroutine(ResetAnimationParameter("PlayS"));
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            // Activar el par�metro de la animaci�n "J"
            animator.SetBool("PlayJ", true);
            StartCoroutine(ResetAnimationParameter("PlayJ"));
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            // Activar el par�metro de la animaci�n "K"
            animator.SetBool("PlayK", true);
            StartCoroutine(ResetAnimationParameter("PlayK"));
        }
    }

    IEnumerator ResetAnimationParameter(string paramName)
    {
        // Esperar un breve periodo de tiempo (por ejemplo, 0.5 segundos)
        yield return new WaitForSeconds(0.5f);

        // Restablecer el par�metro booleano de la animaci�n a falso
        animator.SetBool(paramName, false);
    }
}
