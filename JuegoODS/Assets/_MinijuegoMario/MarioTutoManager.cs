using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioTutoManager : MonoBehaviour
{
    // Public variable to link the GameObject from the Unity Inspector
    public GameObject targetObject;

    public bool MinijuegoMario;
    public bool MinijuegoMónica;
    // Time duration for which the object will stay active
    public float activeDuration = 7.0f;

    public CuentaAtrásMario CuentaAtrásMario;

    public List <ObjectSpawner> objectSpawners = new List<ObjectSpawner>();

    private void Start()
    {
        CuentaAtrásMario.enabled = false;

        for(int i = 0; i < objectSpawners.Count; i++)
        {
            objectSpawners[i].enabled = false;
        }

        Invoke("ActivarJuegoMario", 4.5f);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SaltarNivel();
        }
    }

    public void SaltarNivel()
    {
        SceneManager.LoadScene("SelecciónNivel");
        if (MinijuegoMario)
        {
            SelectorNivel.marioCompletado = true;
        }
        if(MinijuegoMónica)
        {
            SelectorNivel.monicaCompletado = true;
        }   
    }

    public void ActivarJuegoMario()
    {
        CuentaAtrásMario.enabled = true;

        for (int i = 0; i < objectSpawners.Count; i++)
        {
            objectSpawners[i].enabled = true;
        }
    }
}

