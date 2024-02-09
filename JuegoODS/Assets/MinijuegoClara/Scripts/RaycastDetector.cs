using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    public float raycastDistance = 10f;

    public string mensageDetección;

    // Tag del objeto que queremos detectar
    public string targetTag = "Victory_Cube";

    // Dirección del raycast configurable desde el Inspector
    public Vector3 raycastDirection = -Vector3.right;

    void Update()
    {
        // Origen del raycast
        Vector3 raycastOrigin = transform.position;

        // Lanzar el raycast
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, raycastDirection, out hit, raycastDistance))
        {
            // Verificar si el objeto impactado tiene el tag deseado
            if (hit.collider.CompareTag(targetTag))
            {
                Debug.Log(mensageDetección);
            }
        }
    }

    // Dibujar el raycast en la escena con Gizmos
    private void OnDrawGizmos()
    {
        // Color del raycast en la escena
        Gizmos.color = Color.red;

        // Origen del raycast
        Vector3 raycastOrigin = transform.position;

        // Dibujar el raycast
        Gizmos.DrawRay(raycastOrigin, raycastDirection * raycastDistance);
    }

    
}
