using UnityEngine;

public class RotarCamara : MonoBehaviour
{
    public Transform pivote;  // Objeto que actuará como pivote para la rotación de la cámara
    public float velocidadRotacion = 5f;  // Velocidad de rotación de la cámara

    void Update()
    {
        // Rotar la cámara hacia la izquierda con la tecla Y
        if (Input.GetKey(KeyCode.Y))
        {
            RotarCamera(-1);
        }

        // Rotar la cámara hacia la derecha con la tecla U
        if (Input.GetKey(KeyCode.U))
        {
            RotarCamera(1);
        }
    }

    void RotarCamera(int direccion)
    {
        // Calcular el ángulo de rotación
        float anguloRotacion = velocidadRotacion * direccion * Time.deltaTime;

        // Rotar la cámara alrededor del pivote
        transform.RotateAround(pivote.position, Vector3.up, anguloRotacion);
    }
}
