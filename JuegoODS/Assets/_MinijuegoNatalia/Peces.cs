using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    // Array de puntos a los que el objeto puede moverse
    public Transform[] points;
    // Velocidad del objeto
    public float speed = 1.0f;

    // Índice del punto actual
    private int currentPointIndex;

    void Start()
    {
        // Seleccionar un punto aleatorio al inicio
        SelectRandomPoint();
    }

    void Update()
    {
        if (points.Length == 0)
            return;

        // Mover el objeto hacia el punto seleccionado
        MoveTowardsPoint();
    }

    void SelectRandomPoint()
    {
        // Elegir un índice aleatorio del array de puntos
        currentPointIndex = Random.Range(0, points.Length);
    }

    void MoveTowardsPoint()
    {
        // Obtener la posición del punto actual
        Vector3 targetPosition = points[currentPointIndex].position;
        // Mover el objeto hacia la posición del punto
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Comprobar si el objeto ha alcanzado el punto
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Seleccionar un nuevo punto aleatorio
            SelectRandomPoint();
        }
    }
}
