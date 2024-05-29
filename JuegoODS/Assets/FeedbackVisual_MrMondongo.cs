using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FeedbackVisual_MrMondongo : MonoBehaviour
{
    public GameObject Flecha;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactuador"))
        {
            Flecha.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactuador"))
        {
            Flecha.SetActive(false);
        }
    }
}
