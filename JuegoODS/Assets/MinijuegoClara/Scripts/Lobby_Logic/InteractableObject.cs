using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public void Interactuar()
    {
        SceneManager.LoadScene("MinigameSelectionClara");
        Debug.Log("Interactuando con: " + gameObject.name);
    }
}
