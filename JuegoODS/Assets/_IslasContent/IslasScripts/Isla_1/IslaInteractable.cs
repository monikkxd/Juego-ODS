using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslaInteractable : MonoBehaviour
{
    public void Interactuar()
    {
        Debug.Log("Interactuando con: " + gameObject.name);
    }
}
