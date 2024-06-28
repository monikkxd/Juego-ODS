using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoController : MonoBehaviour
{

    // Referencia al controlador de la barra de progreso
    public ProgressBarController progressBarController;
    public ParticleSystem destructionParticles;

    public void DestroyFuego()
    {
        // Notificar al controlador de la barra de progreso
        if (progressBarController != null)
        {
            Debug.Log("fuegoCiontroller");
            progressBarController.DestroyObject(gameObject);
            ParticleSystem instantiatedParticles = Instantiate(destructionParticles, transform.position, transform.rotation);
            instantiatedParticles.Play();

            // Optionally, destroy the particle system after it has played
            Destroy(instantiatedParticles.gameObject, instantiatedParticles.main.duration);
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
