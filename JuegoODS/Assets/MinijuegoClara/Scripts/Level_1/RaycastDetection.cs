using UnityEngine;

public class RaycastDetection : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;

    private bool hitObjeto1 = false;
    private bool hitObjeto2 = false;

    void Update()
    {
        
        hitObjeto1 = IsHitByRaycast(objeto1);
        hitObjeto2 = IsHitByRaycast(objeto2);



        
        if (hitObjeto1 && hitObjeto2)
        {
            
            Debug.Log("Victoria");
            
        }
        else
        {
            // Mostrar mensajes individuales
            if (hitObjeto1)
            {
                Debug.Log("Objeto1 golpeado");
            }

            if (hitObjeto2)
            {
                Debug.Log("Objeto2 golpeado");
            }
        }
    }

    bool IsHitByRaycast(GameObject objeto)
    {
        RaycastHit hit;

        // Lanzar un raycast desde la posición actual hacia adelante
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Comprobar si el objeto es golpeado por el raycast con el tag "Raycast"
            return hit.collider.CompareTag("Raycast") && hit.collider.gameObject == objeto;
        }

        return false;
    }

}
