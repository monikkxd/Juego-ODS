using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicaManager : MonoBehaviour
{
    public GameObject fadeIn;

    public Animator animator;

    public GameObject acelerandoTransición;
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            fadeIn.SetActive(true);
            Invoke("CambioEscena", 2.3f);
        }
        
        if(Input.GetKey(KeyCode.E))
        {
            acelerandoTransición.SetActive(true);
            Time.timeScale = 4f;
        }
        else
        {
            acelerandoTransición.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    void CambioEscena()
    {
        SceneManager.LoadScene("SelecciónNivel");
    }
}
