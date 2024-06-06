using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Manager : MonoBehaviour
{
    public List<GameObject> gameObjectList = new List<GameObject>();
    public GameObject activador;
    public GameObject transici�n;
    public GameObject transici�nFinal;
    public GameObject audioSource;

    private void Start()
    {
        activador.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Victory_Collider"))
        {
            audioSource.SetActive(false);
            activador.SetActive(true);
            transici�nFinal.SetActive(true);


            for(int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].SetActive(false);
            }
           
            Invoke("ActivarTransici�n", 3f);
            Invoke("CambiarEscena", 5.5f);
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("SegundaIsla2");
    }

    void ActivarTransici�n()
    {
        transici�n.SetActive(true);
    }
}
