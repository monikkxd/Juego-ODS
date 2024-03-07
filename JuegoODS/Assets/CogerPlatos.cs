using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerPlatos : MonoBehaviour
{
    public GameObject whatCanIPickUp;
    public GameObject holder;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (whatCanIPickUp != null)
            {
                if (whatCanIPickUp.transform.parent == holder.transform)
                {
                    // Already holding an object, check if we are over a table to deposit
                    GameObject detectedTable = GetDetectedTable();
                    if (detectedTable != null)
                    {
                        // Deposit the object on the detected table
                        DepositObject(detectedTable);
                    }
                }
                else
                {
                    // Not holding an object, pick up if over a plate
                    PickUpObject();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plato"))
        {
            whatCanIPickUp = other.gameObject;
            Debug.Log("Se puede coger " + other.gameObject.name);
        }
    }

    bool IsCollidingWithTable()
    {
        // Check if the object with this script is colliding with an object tagged as "Mesa"
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation, LayerMask.GetMask("Mesa"));

        return colliders.Length > 0;
    }

    void PickUpObject()
    {
        whatCanIPickUp.transform.SetParent(holder.transform);
        whatCanIPickUp.transform.localPosition = new Vector3(0, 0, 0);
    }

    void DepositObject(GameObject table)
    {
        // Obtener la posición local deseada en la mesa
        Vector3 depositPosition = new Vector3(0.1f, 0.3f, 0.0f); // Ajusta esto según tus necesidades

        // Establecer la posición y el padre del objeto que se está sosteniendo
        whatCanIPickUp.transform.SetParent(table.transform);
        whatCanIPickUp.transform.localPosition = depositPosition;

        // Añade cualquier lógica adicional que puedas necesitar al depositar el objeto
    }



    GameObject GetDetectedTable()
    {
        // Get the object with the tag "Mesa" that the script is currently colliding with
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation, LayerMask.GetMask("Mesa"));
        if (colliders.Length > 0)
        {
            return colliders[0].gameObject;
        }
        return null;
    }
}
