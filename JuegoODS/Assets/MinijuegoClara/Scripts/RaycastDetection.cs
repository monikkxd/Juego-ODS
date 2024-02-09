using UnityEngine;

public class RaycastDetection : MonoBehaviour
{
    public string targetTag = "TuTag"; // Reemplaza "TuTag" con el tag que deseas detectar
    public GameObject objeto1; // Asigna tu GameObject en el Inspector

    void Update()
    {
        // Llamar al método de detección cuando sea necesario
        CheckRaycastHit(objeto1, targetTag);
    }

    void CheckRaycastHit(GameObject objeto, string tag)
    {
        // Lanzar un rayo desde el objeto
        Ray ray = new Ray(objeto.transform.position, objeto.transform.forward);
        RaycastHit hit;

        // Realizar el raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Verificar si el objeto impactado tiene el tag deseado
            if (hit.collider.CompareTag(tag))
            {
                Debug.Log(objeto.name + " está siendo impactado por un raycast con el tag " + tag);
            }
            else
            {
                Debug.Log(objeto.name + " no está siendo impactado por un raycast con el tag " + tag);
            }
        }
    }
}
