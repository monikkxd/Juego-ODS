using UnityEngine;

public class RotarCamara : MonoBehaviour
{
    public Transform pivote;  // Objeto que actuar� como pivote para la rotaci�n de la c�mara
    public float velocidadRotacion = 5f;  // Velocidad de rotaci�n de la c�mara

    void Update()
    {
        // Rotar la c�mara hacia la izquierda con la tecla Y
        if (Input.GetKey(KeyCode.Y))
        {
            RotarCamera(-1);
        }

        // Rotar la c�mara hacia la derecha con la tecla U
        if (Input.GetKey(KeyCode.U))
        {
            RotarCamera(1);
        }
    }

    void RotarCamera(int direccion)
    {
        // Calcular el �ngulo de rotaci�n
        float anguloRotacion = velocidadRotacion * direccion * Time.deltaTime;

        // Rotar la c�mara alrededor del pivote
        transform.RotateAround(pivote.position, Vector3.up, anguloRotacion);
    }
}
