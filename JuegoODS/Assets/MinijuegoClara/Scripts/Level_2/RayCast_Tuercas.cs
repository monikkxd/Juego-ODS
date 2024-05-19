using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCast_Tuercas : MonoBehaviour
{
    [Header("Objetos Raycast")]
    public GameObject childObject1;
    public GameObject childObject2;
    public GameObject childObject3;

    private int lockCountForObject1 = 0;

    [Header("Objetos Check Victoria")]
    public GameObject cerradura_1;
    public GameObject cerradura_2;
    public GameObject cerradura_3;
    public GameObject cerradura_Final;

    [Header("Color Victoria")]
    public Color colorAUsar = Color.red;

    void Update()
    {
        PerformRaycastAndCountLocks(childObject1);
    }

    void PerformRaycastAndCountLocks(GameObject targetObject)
    {
        if (targetObject != null)
        {
            Vector3 raycastOrigin = targetObject.transform.position;
            Vector3 raycastDirection = targetObject.transform.TransformDirection(Vector3.left);
            float raycastDistance = 5f;

            RaycastHit[] hits = Physics.RaycastAll(raycastOrigin, raycastDirection, raycastDistance);

            int lockCount = 0;
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Cerradura"))
                {
                    lockCount++;
                }
            }

            Debug.Log($"{targetObject.name} detectó {lockCount} objetos con el tag 'Cerradura'");

            if (targetObject == childObject1)
            {
                lockCountForObject1 = lockCount;
                Debug.Log($"Contador para {targetObject.name}: {lockCountForObject1}");

                if (lockCountForObject1 >= 3)
                {
                    Debug.Log("¡Victoria!");
                    PintarObjeto(colorAUsar);
                    Invoke("CambioEscena", 2f);                    
                }
            }

            Debug.DrawRay(raycastOrigin, raycastDirection * raycastDistance, Color.red);
        }
    }

    void PintarObjeto(Color nuevoColor)
    {
        // Obtener el componente Renderer del GameObject
        Renderer renderer1 = cerradura_1.GetComponent<Renderer>();
        Renderer renderer2 = cerradura_2.GetComponent<Renderer>();
        Renderer renderer3 = cerradura_3.GetComponent<Renderer>();
        Renderer renderer4 = cerradura_Final.GetComponent<Renderer>();

        // Verificar si el objeto tiene un componente Renderer
        if (renderer1 != null)
        {
            // Cambiar el color del material
            renderer1.material.color = nuevoColor;
            renderer2.material.color = nuevoColor;
            renderer3.material.color = nuevoColor;
            renderer4.material.color = nuevoColor;
        }
        else
        {
            // Mostrar un mensaje de error si el objeto no tiene un componente Renderer
            Debug.LogError("El objeto no tiene un componente Renderer.");
        }

    }

    void CambioEscena()
    {
        SceneManager.LoadScene("TerceraIsla2");
    }
}
