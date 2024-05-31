using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public string interacterTag; 
    public Color highlightColor = Color.red; 
    public float scaleFactor = 1.5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(interacterTag))
        {
            Renderer objectRenderer = GetComponent<Renderer>();
            if (objectRenderer != null)
            {
                objectRenderer.material.color = highlightColor;
            }

            transform.localScale *= scaleFactor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(interacterTag))
        {
            Renderer objectRenderer = GetComponent<Renderer>();
            if (objectRenderer != null)
            {
                objectRenderer.material.color = Color.white; 
            }

            transform.localScale /= scaleFactor;
        }
    }
}
