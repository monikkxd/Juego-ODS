using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerPlatos : MonoBehaviour
{
    public GameObject whatCanIPickUp;
    public GameObject holder;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Plato"))
        {
            whatCanIPickUp = other.gameObject;
            Debug.Log("Se puede coger" + other.gameObject.name);
        }
    }

    void PickUpObject()
    {
        whatCanIPickUp.transform.SetParent(holder.transform);
        //whatCanIPickUp.transform.localScale = new Vector3(1f, 1f, 1f);
        whatCanIPickUp.transform.localPosition = new Vector3(0, 0, 0);
    }

}
