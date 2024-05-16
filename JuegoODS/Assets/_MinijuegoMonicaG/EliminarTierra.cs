using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarTierra : MonoBehaviour
{
    // Referencia al collider que se activará con la tecla E
    public Collider eliminadorCollider;

    // Referencia al tiempo de espera antes de eliminar los objetos
    public float tiempoDeEspera = 2f;

    // Método para activar el collider cuando se presiona la tecla E
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            eliminadorCollider.enabled = true;
            Invoke("DesactivarCollider", tiempoDeEspera); // Invocamos el método para desactivar el collider después de 2 segundos
        }
    }

    // Método para desactivar el collider
    void DesactivarCollider()
    {
        eliminadorCollider.enabled = false;
    }

    // Método que se llama cuando un objeto entra en el collider
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto tiene el tag "tierra" antes de eliminarlo
        if (other.CompareTag("tierra"))
        {
            // Eliminamos el objeto después de 2 segundos
            Destroy(other.gameObject, tiempoDeEspera);
        }
    }
}

