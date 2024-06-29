using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventS : MonoBehaviour
{
    public Button BotonInicial;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BotonInicial.Select();
        }
    }
}
