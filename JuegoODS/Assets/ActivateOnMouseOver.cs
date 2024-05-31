using UnityEngine;

public class ActivateOnMouseOver : MonoBehaviour
{
    // El objeto que se activará/desactivará
    public GameObject targetObject;

    private void Start()
    {
        // Asegúrate de que el objeto de destino está desactivado al inicio
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        // Activa el objeto cuando el ratón está sobre el collider
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        // Desactiva el objeto cuando el ratón deja de estar sobre el collider
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
