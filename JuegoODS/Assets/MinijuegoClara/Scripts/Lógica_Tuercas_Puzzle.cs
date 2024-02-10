using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lógica_Tuercas_Puzzle : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    public float selectionDistance = 2f;
    public float rotationSpeed = 5f; // Velocidad de rotación
    private float targetRotation = 0f;

    private List<Transform> selectableObjects = new List<Transform>();
    private List<Color> originalColors = new List<Color>();
    private int selectedIndex = 0;

    private bool isRotating = false; // Variable para rastrear si el objeto está en proceso de rotación

    private void Start()
    {
        // Obtén todos los hijos del objeto vacío
        foreach (Transform child in transform)
        {
            selectableObjects.Add(child);

            // Almacena el color original de cada objeto
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                originalColors.Add(renderer.material.color);
            }
            else
            {
                originalColors.Add(Color.white); // Puedes ajustar esto según el color predeterminado que desees
            }
        }

        // Selecciona el primer objeto por defecto
        if (selectableObjects.Count > 0)
        {
            SelectObject(selectedIndex);
        }
    }

    private void Update()
    {
        // Detecta las teclas A y D para cambiar la selección
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeSelection(-1); // Moverse al objeto anterior
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeSelection(1); // Moverse al siguiente objeto
        }

        // Detecta las teclas Q y E para rotar suavemente el objeto seleccionado en el eje Y
        if (!isRotating && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)))
        {
            targetRotation = selectableObjects[selectedIndex].eulerAngles.y + (Input.GetKeyDown(KeyCode.Q) ? -90f : 90f);
            StartCoroutine(RotateObject());
        }
    }

    private void ChangeSelection(int direction)
    {
        // Deselecciona el objeto actual
        DeselectObject(selectedIndex);

        // Cambia el índice de selección
        selectedIndex = (selectedIndex + direction + selectableObjects.Count) % selectableObjects.Count;

        // Selecciona el nuevo objeto
        SelectObject(selectedIndex);
    }

    private void SelectObject(int index)
    {
        // Resalta el objeto seleccionado con el color de selección
        Renderer renderer = selectableObjects[index].GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = highlightColor;
        }
    }

    private void DeselectObject(int index)
    {
        // Restaura el color original del objeto deseleccionado
        Renderer renderer = selectableObjects[index].GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = originalColors[index];
        }
    }

    private IEnumerator RotateObject()
    {
        isRotating = true;

        float startRotation = selectableObjects[selectedIndex].eulerAngles.y;
        float timeElapsed = 0f;

        while (timeElapsed < rotationSpeed)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / rotationSpeed);
            float currentRotation = Mathf.LerpAngle(startRotation, targetRotation, t);
            selectableObjects[selectedIndex].rotation = Quaternion.Euler(0f, currentRotation, 0f);
            yield return null;
        }

        // Aseguramos que la rotación sea exacta después de completar la rutina
        selectableObjects[selectedIndex].rotation = Quaternion.Euler(0f, targetRotation, 0f);

        isRotating = false;
    }
}
