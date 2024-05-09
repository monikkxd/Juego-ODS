using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpRotacion : MonoBehaviour
{
    public float velocidadRotacion = 50f; 

    void Update()
    {
        // Rotar el objeto constantemente en el eje X
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
