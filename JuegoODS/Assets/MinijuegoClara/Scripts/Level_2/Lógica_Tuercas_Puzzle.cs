using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lógica_Tuercas_Puzzle : MonoBehaviour
{
    public Color highlightColor = Color.yellow;
    public float selectionDistance = 2f;
    public float rotationSpeed = 5f;
    private float targetRotation = 0f;

    private List<Transform> selectableObjects = new List<Transform>();
    private List<Color> originalColors = new List<Color>();
    private int selectedIndex = 0;

    private bool isRotating = false;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            selectableObjects.Add(child);

            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                originalColors.Add(renderer.material.color);
            }
            else
            {
                originalColors.Add(Color.white);
            }
        }

        if (selectableObjects.Count > 0)
        {
            SelectObject(selectedIndex);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeSelection(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeSelection(1);
        }

        if (!isRotating && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R)))
        {
            targetRotation = selectableObjects[selectedIndex].eulerAngles.y + (Input.GetKeyDown(KeyCode.E) ? -90f : 90f);
            StartCoroutine(RotateObject());
        }
    }

    private void ChangeSelection(int direction)
    {
        // Si está rotando, no permitir cambiar la selección
        if (isRotating)
        {
            return;
        }

        DeselectObject(selectedIndex);

        selectedIndex = (selectedIndex + direction + selectableObjects.Count) % selectableObjects.Count;

        SelectObject(selectedIndex);
    }

    private void SelectObject(int index)
    {
        Renderer renderer = selectableObjects[index].GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = highlightColor;
        }
    }

    private void DeselectObject(int index)
    {
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

        selectableObjects[selectedIndex].rotation = Quaternion.Euler(0f, targetRotation, 0f);

        isRotating = false;
    }
}
