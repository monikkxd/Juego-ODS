using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicaManager : MonoBehaviour
{
    public GameObject fadeIn;

    public Animator animator;

    public GameObject acelerandoTransici�n;
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            fadeIn.SetActive(true);
            Invoke("CambioEscena", 2.3f);
        }
        
        if(Input.GetKey(KeyCode.E))
        {
            acelerandoTransici�n.SetActive(true);
            Time.timeScale = 4f;
        }
        else
        {
            acelerandoTransici�n.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    void CambioEscena()
    {
        SceneManager.LoadScene("Selecci�nNivel");
    }
}
