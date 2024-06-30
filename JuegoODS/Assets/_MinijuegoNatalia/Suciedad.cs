using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suciedad : MonoBehaviour
{
    public float duration = 120f; // Duración total en segundos (2 minutos)
    private Material material;
    private Color originalColor;

    void Start()
    {
        // Obtener el material del Quad
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            originalColor = material.color;
            // Iniciar la corutina para hacer el fade out
            StartCoroutine(FadeToTransparent());
        }
        else
        {
            Debug.LogError("No se encontró Renderer en el objeto.");
        }
    }

    IEnumerator FadeToTransparent()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calcular el nuevo valor de alpha
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsedTime / duration);
            // Aplicar el nuevo color al material
            material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Incrementar el tiempo transcurrido
            elapsedTime += Time.deltaTime;

            // Esperar hasta el siguiente frame
            yield return null;
        }

        // Asegurarse de que el Quad sea completamente transparente al final
        material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}

