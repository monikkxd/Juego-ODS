using UnityEngine;

public class ResetOnCollision : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objeto_Grua"))
        {
            // Destruir el objeto
            Destroy(gameObject);

            GameObject newObj = Instantiate(gameObject, initialPosition, initialRotation);
            newObj.name = gameObject.name; 
        }
    }
}
