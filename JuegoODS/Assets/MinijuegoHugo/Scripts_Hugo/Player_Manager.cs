using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public List<GameObject> gameObjectList = new List<GameObject>();
    public GameObject activador;

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

        }
        
    }
}
