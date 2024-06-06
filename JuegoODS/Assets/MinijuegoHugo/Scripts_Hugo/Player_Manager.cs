using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Manager : MonoBehaviour
{
    public List<GameObject> gameObjectList = new List<GameObject>();
    public GameObject activador;
    public GameObject transición;
    public GameObject transiciónFinal;
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
            transiciónFinal.SetActive(true);


            for(int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].SetActive(false);
            }
           
            Invoke("ActivarTransición", 3f);
            Invoke("CambiarEscena", 5.5f);
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("SegundaIsla2");
    }

    void ActivarTransición()
    {
        transición.SetActive(true);
    }
}
