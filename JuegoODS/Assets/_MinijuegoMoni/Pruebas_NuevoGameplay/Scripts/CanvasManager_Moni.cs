using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager_Moni : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private bool interfazCambiada = false;
    [SerializeField] private bool interfazCambiada2 = false;
    [SerializeField] private bool interfazCambiada3 = false;

    private void Start()
    {
        animator.enabled = false;
    }
    public void CambioInterfaz()
    {
        if(interfazCambiada == false)
        {
            animator.enabled = true;

            interfazCambiada = true;

            animator.Play("CambioInterfaz_Animation");
        }
        else if(interfazCambiada == true & interfazCambiada2 == false)
        {
            interfazCambiada2 = true;
            interfazCambiada3 = true;
            animator.Play("CambioInterfaz3_Animation");
        }

    }

    public void CambioInterfaz2()
    {
        if(interfazCambiada == true && interfazCambiada2 == false)
        {
            interfazCambiada = false;
            interfazCambiada2 = false;

            animator.Play("CambioInterfaz2_Animation");
        }
        else if(interfazCambiada3 == true)
        {
            interfazCambiada = true;
            interfazCambiada2 = false;
            interfazCambiada3 = false;
            animator.Play("CambioInterfaz4_Animation");
        }
    }


}
