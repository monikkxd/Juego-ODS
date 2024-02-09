using UnityEngine;

public class Rotación_Cubo_Prueba : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(_rotation * Time.deltaTime);
        }
        
        Debug.Log("SimpleRotate Activado...");
    }
}
