using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;         // Velocidad de movimiento del jugador
    public float rotationSpeed = 200f;   // Velocidad de rotaci�n del jugador

    void Update()
    {
        // Obt�n el input horizontal (teclas A y D)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcula la rotaci�n basada en el input horizontal
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        // Aplica la rotaci�n al jugador
        transform.Rotate(0f, rotation, 0f);

        // Obt�n el input vertical (tecla W)
        float verticalInput = Input.GetAxis("Vertical");

        // Si se presiona la tecla W, avanza
        if (verticalInput >= 0.1f)
        {
            // Calcula el vector de movimiento en el espacio del jugador
            Vector3 move = transform.forward * moveSpeed * Time.deltaTime;

            // Aplica el movimiento al jugador
            transform.Translate(move, Space.World);
        }
    }
}