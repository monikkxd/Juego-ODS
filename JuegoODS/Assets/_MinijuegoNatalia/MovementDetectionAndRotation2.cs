using UnityEngine;

public class MovementDetectionAndRotation2 : MonoBehaviour
{
    private Vector3 previousPosition;

    void Start()
    {
        // Inicializa la posici�n anterior como la posici�n actual del objeto
        previousPosition = transform.position;
    }

    void Update()
    {
        // Obtiene la posici�n actual del objeto
        Vector3 currentPosition = transform.position;

        // Compara la posici�n actual con la anterior para determinar la direcci�n del movimiento
        if (currentPosition.x > previousPosition.x)
        {
            Debug.Log("Movi�ndose a la derecha");
            // Rota el objeto 180 grados en el eje Y cuando se mueva a la derecha
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (currentPosition.x < previousPosition.x)
        {
            Debug.Log("Movi�ndose a la izquierda");
            // Restablece la rotaci�n cuando se mueva a la izquierda
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Actualiza la posici�n anterior para el siguiente frame
        previousPosition = currentPosition;
    }
}
