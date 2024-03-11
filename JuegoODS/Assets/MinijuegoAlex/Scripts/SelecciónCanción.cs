using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecciónCanción : MonoBehaviour
{

    private int Ncancion;

    public GameObject cancion1;
    public GameObject cancion2;
    
   
    void Start()
    {
        Ncancion = 0;
    }

   
    void Update()
    {
        if(Ncancion == 0)
        {
            cancion1.SetActive(true);
            cancion2.SetActive(false);
            
        }
        if(Ncancion == 1)
        {
            cancion1.SetActive(false);
            cancion2.SetActive(true);
            
        }
        if (Ncancion > 1)
        {
            Ncancion = 0;
        }
        if(Ncancion < 0)
        {
            Ncancion = 1;
        }
    }


    public void ClickDerecha()
    {
        Ncancion++;
    }

    public void ClickIzquierda()
    {
        Ncancion--;
    }
}


