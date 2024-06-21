using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager_Moni : MonoBehaviour
{
    public Animator animator;

    private bool interfazCambiada = false;
    private bool interfazCambiada2 = false;
    private bool interfazCambiada3 = false;

    private void Start()
    {
        animator.enabled = false;
    }
    public void CambioInterfaz()
    {
        animator.enabled = true;


    }

    public void CambioInterfaz2()
    {
        
    }


}
