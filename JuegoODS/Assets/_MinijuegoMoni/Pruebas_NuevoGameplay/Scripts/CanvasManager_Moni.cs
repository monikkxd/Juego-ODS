using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager_Moni : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private bool interfazCambiada = false;
    [SerializeField] private bool interfazCambiada2 = false;
    [SerializeField] private bool interfazCambiada3 = false;

    public GameObject primerMenu, segundoMenu, tercerMenu;

    private void Start()
    {
        animator.enabled = false;
        primerMenu.SetActive(true);
    }
    public void CambioInterfaz()
    {
        if (interfazCambiada == false)
        {
            animator.enabled = true;

            interfazCambiada = true;

            primerMenu.SetActive(false);
            segundoMenu.SetActive(true);
            tercerMenu.SetActive(false);
            animator.Play("CambioInterfaz_Animation");
        }
        else if (interfazCambiada == true & interfazCambiada2 == false)
        {
            interfazCambiada2 = true;
            interfazCambiada3 = true;

            primerMenu.SetActive(false);
            segundoMenu.SetActive(false);
            tercerMenu.SetActive(true);

            animator.Play("CambioInterfaz3_Animation");
        }

    }

    public void CambioInterfaz2()
    {
        if (interfazCambiada == true && interfazCambiada2 == false)
        {
            interfazCambiada = false;
            interfazCambiada2 = false;

            primerMenu.SetActive(true);
            segundoMenu.SetActive(false);
            tercerMenu.SetActive(false);

            animator.Play("CambioInterfaz2_Animation");
        }
        else if (interfazCambiada3 == true)
        {
            interfazCambiada = true;
            interfazCambiada2 = false;
            interfazCambiada3 = false;
            animator.Play("CambioInterfaz4_Animation");

            primerMenu.SetActive(false);
            segundoMenu.SetActive(true);
            tercerMenu.SetActive(false);
        }
    }


}
