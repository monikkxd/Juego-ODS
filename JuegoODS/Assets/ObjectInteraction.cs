using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public string interacterTag; // Tag del objeto con el que interactuar
    public Color highlightColor = Color.red; // Color a aplicar al objeto al interactuar
    public float scaleFactor = 1.5f; // Factor de escala para aumentar el tama�o

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(interacterTag))
        {
            // Cambiar el color del objeto a highlightColor
            Renderer objectRenderer = GetComponent<Renderer>();
            if (objectRenderer != null)
            {
                objectRenderer.material.color = highlightColor;
            }

            // Aumentar el tama�o del objeto
            transform.localScale *= scaleFactor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(interacterTag))
        {
            // Restaurar el color original del objeto
            Renderer objectRenderer = GetComponent<Renderer>();
            if (objectRenderer != null)
            {
                // Aqu� podr�as guardar el color original en una variable para restaurarlo
                objectRenderer.material.color = Color.white; // o restaurar a otro color original
            }

            // Restaurar el tama�o original del objeto
            transform.localScale /= scaleFactor;
        }
    }
}
