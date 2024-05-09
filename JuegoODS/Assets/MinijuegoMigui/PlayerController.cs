using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;         // Velocidad de movimiento del jugador
    public float rotationSpeed = 200f;   // Velocidad de rotación del jugador

    void Update()
    {
        // Obtén el input horizontal (teclas A y D)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcula la rotación basada en el input horizontal
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        // Aplica la rotación al jugador
        transform.Rotate(0f, rotation, 0f);

        // Obtén el input vertical (tecla W)
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