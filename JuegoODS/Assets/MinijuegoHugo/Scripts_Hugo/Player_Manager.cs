using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Manager : MonoBehaviour
{
    public List<GameObject> gameObjectList = new List<GameObject>();
    public GameObject activador;
    public GameObject transici�n;

    private void Start()
    {
        activador.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Victory_Collider"))
        {
            
            activador.SetActive(true);

            for(int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].SetActive(false);
            }
            transici�n.SetActive(true);
            Invoke("CambiarEscena", 6f);
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("SegundaIsla2");
    }
}
