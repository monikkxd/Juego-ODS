using System.Collections.Generic;
using UnityEngine;

public class Cocinero : MonoBehaviour
{
    public List<GameObject> platosDisponibles;
    public Transform barraDePlatos;
    public float velocidadMovimiento = 5f;

    private void Start()
    {
        Debug.Log("Active? " + gameObject.activeInHierarchy);
    }

    public void MoverCocinero(Vector3 posicionDeInstancia, Transform puntoEnLaBarra)
    {
        if (platosDisponibles.Count > 0)
        {
            GameObject platoAleatorio = platosDisponibles[Random.Range(0, platosDisponibles.Count)];

            GameObject nuevoCocinero = Instantiate(gameObject, posicionDeInstancia, Quaternion.identity);
            // Instancia el plato en la posición del cocinero
            GameObject nuevoPlato = Instantiate(platoAleatorio, transform.position, Quaternion.identity);
            nuevoPlato.transform.parent = nuevoCocinero.transform;

            MoverHaciaLaBarra(nuevoCocinero.transform, puntoEnLaBarra);
        }
    }

    void MoverHaciaLaBarra(Transform cocineroTransform, Transform puntoEnLaBarra)
    {
        while (Vector3.Distance(cocineroTransform.position, puntoEnLaBarra.position) > 0.1f)
        {
            cocineroTransform.position = Vector3.MoveTowards(cocineroTransform.position, puntoEnLaBarra.position, velocidadMovimiento * Time.deltaTime);
        }
        // Deja el plato en la barra
        DejarPlatoEnBarra(cocineroTransform);

        Destroy(cocineroTransform.gameObject);
    }

    void DejarPlatoEnBarra(Transform cocineroTransform)
    {
        cocineroTransform.GetChild(0).position = cocineroTransform.position;
        cocineroTransform.GetChild(0).parent = null;
    }
}
