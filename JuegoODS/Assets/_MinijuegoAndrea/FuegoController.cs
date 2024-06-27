using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoController : MonoBehaviour
{

    // Referencia al controlador de la barra de progreso
    public ProgressBarController progressBarController;

    void OnDestroy()
    {
        // Notificar al controlador de la barra de progreso
        if (progressBarController != null)
        {
            progressBarController.DestroyObject(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
