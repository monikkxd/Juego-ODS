using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public GameObject barrera1;
    public GameObject barrera2;
    public GameObject barrera3;
    public GameObject barrera4;

    private Mover_Vehículos moverVehiculos;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Victory_Collider"))
        {
            barrera1.SetActive(false);
            barrera2.SetActive(false);
            barrera3.SetActive(false);
            barrera4.SetActive(false);

            return;
        }
        
    }
}
