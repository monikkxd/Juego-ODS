using UnityEngine;

public class PlatoDetector : MonoBehaviour
{
    private bool tienePlato = false;

    public bool TienePlato()
    {
        return tienePlato;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plato"))
        {
            tienePlato = true;
            Debug.Log("Plato detectado");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plato"))
        {
            tienePlato = false;
            Debug.Log("Plato Recogido");
        }
    }
}
