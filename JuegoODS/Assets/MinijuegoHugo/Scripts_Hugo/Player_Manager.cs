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

    private SelectorNivel selectorNivel;

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

            for(int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].SetActive(false);
            }
            SelectorNivel.hugoCompletado = true;
            Invoke("ActivarTransiciónFinal", 1.5f);
            Invoke("ActivarTransición", 5.5f);
            Invoke("CambiarEscena", 8f);
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("SelecciónNivel");
    }

    void ActivarTransición()
    {
        transición.SetActive(true);
    }

    void ActivarTransiciónFinal()
    {
        transiciónFinal.SetActive(true);
    }
}
