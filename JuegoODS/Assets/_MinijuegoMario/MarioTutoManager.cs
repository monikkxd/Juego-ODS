using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioTutoManager : MonoBehaviour
{
    // Public variable to link the GameObject from the Unity Inspector
    public GameObject targetObject;

    public bool MinijuegoMario;
    public bool MinijuegoM�nica;
    // Time duration for which the object will stay active
    public float activeDuration = 7.0f;

    public CuentaAtr�sMario CuentaAtr�sMario;

    public List <ObjectSpawner> objectSpawners = new List<ObjectSpawner>();

    private void Start()
    {
        CuentaAtr�sMario.enabled = false;

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
        SceneManager.LoadScene("Selecci�nNivel");
        if (MinijuegoMario)
        {
            SelectorNivel.marioCompletado = true;
        }
        if(MinijuegoM�nica)
        {
            SelectorNivel.monicaCompletado = true;
        }   
    }

    public void ActivarJuegoMario()
    {
        CuentaAtr�sMario.enabled = true;

        for (int i = 0; i < objectSpawners.Count; i++)
        {
            objectSpawners[i].enabled = true;
        }
    }
}

