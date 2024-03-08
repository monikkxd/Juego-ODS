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

        if (other.CompareTag("Plato"))
        {
            Debug.Log("Plato Detecto");
        }
        else
        {
            Debug.Log("No se ha detectado plato");
        }

    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plato"))
        {
            Debug.Log("Plato Detecto");
        }
        else
        {
            Debug.Log("No se ha detectado plato");
        }
    }
*/
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cliente"))
        {
            Debug.Log("Cliente ha dejado la mesa");
            clienteEnMesa = true;
        }
    }
}
