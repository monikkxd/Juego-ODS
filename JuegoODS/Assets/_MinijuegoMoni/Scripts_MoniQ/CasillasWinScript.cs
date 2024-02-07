using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillasWinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WinTag"))
        {
            Debug.Log("Victoria");
        }
    }
}
