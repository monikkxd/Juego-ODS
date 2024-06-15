using UnityEngine;

public class MovementDetectionAndRotation2 : MonoBehaviour
{
    private Vector3 previousPosition;

    void Start()
    {
        // Inicializa la posición anterior como la posición actual del objeto
        previousPosition = transform.position;
    }

    void Update()
    {
        // Obtiene la posición actual del objeto
        Vector3 currentPosition = transform.position;

        // Compara la posición actual con la anterior para determinar la dirección del movimiento
        if (currentPosition.x > previousPosition.x)
        {
            Debug.Log("Moviéndose a la derecha");
            // Rota el objeto 180 grados en el eje Y cuando se mueva a la derecha
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentPosition.x < previousPosition.x)
        {
            Debug.Log("Moviéndose a la izquierda");
            // Restablece la rotación cuando se mueva a la izquierda
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Actualiza la posición anterior para el siguiente frame
        previousPosition = currentPosition;
    }
}
