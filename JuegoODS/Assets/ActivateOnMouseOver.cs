using UnityEngine;

public class ActivateOnMouseOver : MonoBehaviour
{
    // El objeto que se activar�/desactivar�
    public GameObject targetObject;

    private void Start()
    {
        // Aseg�rate de que el objeto de destino est� desactivado al inicio
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        // Activa el objeto cuando el rat�n est� sobre el collider
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        // Desactiva el objeto cuando el rat�n deja de estar sobre el collider
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
