using UnityEngine;

public class Rotación_Cubo_Prueba : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }
}
