using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerPlatos : MonoBehaviour
{
    public GameObject whatCanIPickUp;
    public GameObject holder;
    private bool holdingPlate = false; // Variable para rastrear si se está sosteniendo un plato

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!holdingPlate && whatCanIPickUp != null) // Solo permitir recoger si no se está sosteniendo un plato y hay un plato disponible
            {
                PickUpObject();
                holdingPlate = true; // Ahora se está sosteniendo un plato
            }
            else if (holdingPlate) // Si ya se está sosteniendo un plato
            {
                GameObject detectedTable = GetDetectedTable();
                if (detectedTable != null)
                {
                    DepositObject(detectedTable);
                    holdingPlate = false; // Se depositó el plato, ya no se está sosteniendo
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plato") && !holdingPlate)
        {
            whatCanIPickUp = other.gameObject;
            Debug.Log("Se puede coger " + other.gameObject.name);
        }
    }

    void PickUpObject()
    {
        whatCanIPickUp.transform.SetParent(holder.transform);
        whatCanIPickUp.transform.localPosition = Vector3.zero; // Ajusta la posición local al centro del holder
    }

    void DepositObject(GameObject table)
    {
        Vector3 depositPosition = new Vector3(0.0f, 0.3f, 0.0f); // Posición local en la mesa

        whatCanIPickUp.transform.SetParent(table.transform);
        whatCanIPickUp.transform.localPosition = depositPosition;

        // Agrega cualquier lógica adicional al depositar el objeto

        whatCanIPickUp = null; // Limpiar la referencia al plato que se depositó
    }

    GameObject GetDetectedTable()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation, LayerMask.GetMask("Mesa"));
        if (colliders.Length > 0)
        {
            return colliders[0].gameObject;
        }
        return null;
    }
}
