using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public GameObject Transici�n;
    public void Interactuar()
    {
        Transici�n.SetActive(true);
        Invoke("CargarMinijuego", 3f);
    }

    public void CargarMinijuego()
    {
        SceneManager.LoadScene("Minijuego Clara");
    }
}
