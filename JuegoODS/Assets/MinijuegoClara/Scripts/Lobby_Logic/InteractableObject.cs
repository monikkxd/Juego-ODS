using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public GameObject Transición;
    public void Interactuar()
    {
        Transición.SetActive(true);
        Invoke("CargarMinijuego", 3f);
    }

    public void CargarMinijuego()
    {
        SceneManager.LoadScene("Minijuego Clara");
    }
}
