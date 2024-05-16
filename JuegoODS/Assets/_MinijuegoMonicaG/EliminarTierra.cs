using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarTierra : MonoBehaviour
{
    // Referencia al collider que se activar� con la tecla E
    public Collider eliminadorCollider;

    // Referencia al tiempo de espera antes de eliminar los objetos
    public float tiempoDeEspera = 2f;

    // M�todo para activar el collider cuando se presiona la tecla E
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            eliminadorCollider.enabled = true;
            Invoke("DesactivarCollider", tiempoDeEspera); // Invocamos el m�todo para desactivar el collider despu�s de 2 segundos
        }
    }

    // M�todo para desactivar el collider
    void DesactivarCollider()
    {
        eliminadorCollider.enabled = false;
    }

    // M�todo que se llama cuando un objeto entra en el collider
    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto tiene el tag "tierra" antes de eliminarlo
        if (other.CompareTag("tierra"))
        {
            // Eliminamos el objeto despu�s de 2 segundos
            Destroy(other.gameObject, tiempoDeEspera);
        }
    }
}

