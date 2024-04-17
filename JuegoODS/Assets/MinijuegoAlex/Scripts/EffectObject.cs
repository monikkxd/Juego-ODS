using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float TiempoVida = 1f;

    void Start()
    {
        
    }
    void Update()
    {
        Destroy(gameObject, TiempoVida);
    }
}
