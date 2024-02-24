using UnityEngine;

public class Mesa : MonoBehaviour
{
    public bool clienteEnMesa = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cliente"))
        {
            Debug.Log("Cliente ha llegado a la mesa");
            clienteEnMesa = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cliente"))
        {
            Debug.Log("Cliente ha dejado la mesa");
            clienteEnMesa = false;
        }
    }
}
