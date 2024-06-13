using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaltarMinijuegoMoni : MonoBehaviour
{
    public GameObject Transición;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Transición.SetActive(true);
            Invoke("CambioEscena", 1.5f);
        }
      
    }

    void CambioEscena()
    {
        SceneManager.LoadScene("MoniFinal");
    }
}
