using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaltarMinijuegoMoni : MonoBehaviour
{
    public GameObject Transici�n;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Transici�n.SetActive(true);
            Invoke("CambioEscena", 1.5f);
        }
      
    }

    void CambioEscena()
    {
        SceneManager.LoadScene("MoniFinal");
    }
}
