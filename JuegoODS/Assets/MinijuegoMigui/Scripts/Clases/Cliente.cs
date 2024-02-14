using UnityEngine;

public class Cliente : MonoBehaviour
{
    public float velocidadMovimiento = 3f;
    public Mesa mesaAsignada;

    // Método para iniciar el movimiento del cliente
    public void IniciarMovimiento(Vector3 posicionDeInstancia, Transform posicionMesa)
    {
        // Asigna la mesa al cliente
        mesaAsignada = posicionMesa.GetComponent<Mesa>();

        // Llama al método para mover el cliente hacia la mesa
        MoverHaciaLaMesa(posicionDeInstancia, posicionMesa.position);
    }

    // Método para mover el cliente hacia la mesa
    void MoverHaciaLaMesa(Vector3 posicionDeInstancia, Vector3 posicionMesa)
    {
        transform.position = posicionDeInstancia;

        while (Vector3.Distance(transform.position, posicionMesa) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionMesa, velocidadMovimiento * Time.deltaTime);
        }

        // Puedes realizar acciones adicionales aquí, como asignar al cliente a la mesa, etc.
        // mesaAsignada.AsignarCliente(this);

        // Destruye el objeto cliente una vez que llega a la mesa
        Destroy(gameObject);
    }
}
