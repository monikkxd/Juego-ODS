using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager_Moni : MonoBehaviour
{
    public Animator animator;

    private bool interfazCambiada = false;

    private void Start()
    {
        animator.enabled = false;
    }
    public void CambioInterfac()
    {
        if(interfazCambiada == false)
        {
            interfazCambiada = true;

            animator.enabled = true;

            animator.SetBool("CambioInterfaz", false);
        }
        else if(interfazCambiada == true)
        {
            interfazCambiada = false;

            animator.SetBool("CambioInterfaz", true);
        }

       
    }


}
