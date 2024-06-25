using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongondosMoni_Manager : MonoBehaviour
{
    public Animator animator;

    public bool Reproducir_MirarCielo;
    public bool Reproducir_Saltar_1;
    public bool Reproducir_Saltar_2;
    public bool Reproducir_Caer;
    void Update()
    {
        if(Reproducir_MirarCielo == true)
        {
            animator.Play("Mirar_Cielo");
        }
        if (Reproducir_Saltar_1 == true)
        {
            animator.Play("Mondongo_Saludar_1");
        }
        if (Reproducir_Saltar_2 == true)
        {
            animator.Play("Mondongo_Saludar_2");
        }
        if (Reproducir_MirarCielo == true)
        {
            animator.Play("Mirar_C");
        }
    }
}
