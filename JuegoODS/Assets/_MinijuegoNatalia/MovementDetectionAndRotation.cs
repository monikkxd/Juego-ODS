using UnityEngine;

public class MovementDetectionAndRotation : MonoBehaviour
{
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (currentPosition.x > previousPosition.x)
        {
            Debug.Log("Moviéndose a la derecha");
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (currentPosition.x < previousPosition.x)
        {
            Debug.Log("Moviéndose a la izquierda");
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        previousPosition = currentPosition;
    }
}
