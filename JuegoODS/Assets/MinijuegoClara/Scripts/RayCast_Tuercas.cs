using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast_Tuercas : MonoBehaviour
{
    public GameObject childObject1;
    public GameObject childObject2;
    public GameObject childObject3;

    // Contador para el objeto 1
    private int lockCountForObject1 = 0;

    void Update()
    {
        PerformRaycastAndCountLocks(childObject1);
    }

    void PerformRaycastAndCountLocks(GameObject targetObject)
    {
        if (targetObject != null)
        {
            // Obtener la posici�n del objeto objetivo
            Vector3 raycastOrigin = targetObject.transform.position;

            // Obtener la direcci�n actualizada basada en la rotaci�n del objeto
            Vector3 raycastDirection = targetObject.transform.TransformDirection(Vector3.left);

            // Longitud del Raycast (ajusta seg�n sea necesario)
            float raycastDistance = 5f;

            // Realizar el Raycast
            RaycastHit[] hits = Physics.RaycastAll(raycastOrigin, raycastDirection, raycastDistance);

            // Contar objetos con el tag "Cerradura"
            int lockCount = 0;
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Cerradura"))
                {
                    lockCount++;
                }
            }

            // Debug para depurar
            Debug.Log($"{targetObject.name} detect� {lockCount} objetos con el tag 'Cerradura'");

            // Actualizar el contador para el objeto 1
            if (targetObject == childObject1)
            {
                lockCountForObject1 = lockCount;
                Debug.Log($"Contador para {targetObject.name}: {lockCountForObject1}");

                // Mostrar el mensaje "Victoria" si se detectan 3 o m�s objetos con el tag "Cerradura"
                if (lockCountForObject1 >= 3)
                {
                    Debug.Log("�Victoria!");
                }
            }

            // Visualizar el Raycast en la escena a trav�s de Gizmos
            Debug.DrawRay(raycastOrigin, raycastDirection * raycastDistance, Color.red);
        }
    }
}
