using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerPlatos : MonoBehaviour
{
    public GameObject whatCanIPickUp;
    public GameObject holder;
    private bool holdingPlate = false; 

    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!holdingPlate && whatCanIPickUp != null) 
            {
                PickUpObject();
                holdingPlate = true;
                anim.SetBool("hasPlate", true);
            }
            else if (holdingPlate) 
            {
                GameObject detectedTable = GetDetectedTable();
                if (detectedTable != null)
                {
                    DepositObject(detectedTable);
                    holdingPlate = false;
                    anim.SetBool("hasPlate", false);
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
        whatCanIPickUp.transform.localPosition = Vector3.zero;
    }

    void DepositObject(GameObject table)
    {
        Vector3 depositPosition = new Vector3(0.0f, 0.3f, 0.0f); 

        whatCanIPickUp.transform.SetParent(table.transform);
        whatCanIPickUp.transform.localPosition = depositPosition;

        whatCanIPickUp = null; 
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
