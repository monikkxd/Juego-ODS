using System.Collections;
using UnityEngine;

public class Bicicleta_Script : MonoBehaviour
{
    private Animator animator; // Referencia al componente Animator

    private bool idleTrue;
    private bool atrue;
    private bool strue;
    private bool jtrue;
    private bool ktrue;
    void Start()
    {
        // Obtener el componente Animator del objeto actual
        animator = GetComponent<Animator>();
        idleTrue = true;
        atrue = false;
        strue = false;
        jtrue = false;
        ktrue = false;
    }

    void Update()
    {
        // Comprobar las teclas y activar los parámetros de animación
        if (Input.GetKeyDown(KeyCode.A) && idleTrue == true)
        {
            idleTrue = false;
            A();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            idleTrue = false;
            S();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            idleTrue = false;
            J();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            idleTrue = false;
            K();
        }

        if (idleTrue == true) 
        {
            animator.Play("Manos");
        }

    }

    IEnumerator ResetAnimationParameter(string paramName)
    {
        // Esperar un breve periodo de tiempo (por ejemplo, 0.5 segundos)
        yield return new WaitForSeconds(0.1f);
        idleTrue = true;
        // Restablecer el parámetro booleano de la animación a falso
        animator.Play(paramName);
    }

    public void BackTOIdle()
    {
        if(idleTrue)
        {
            animator.Play("Manos");
            atrue = false;
            strue = false;
            jtrue = false;
            ktrue = false;
        }
        
    }

    public void A()
    {
        animator.Play("A");
        StartCoroutine(ResetAnimationParameter("Manos"));
    }
    public void S()
    {
        animator.Play("S");
        StartCoroutine(ResetAnimationParameter("Manos"));
    }
    public void J()
    {
        animator.Play("J");
        StartCoroutine(ResetAnimationParameter("Manos"));
    }
    public void K()
    {
        animator.Play("K");
        StartCoroutine(ResetAnimationParameter("Manos"));
    }
}
