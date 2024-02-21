// Cocinero
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocinero : MonoBehaviour
{
    public List<GameObject> platosDisponibles;
    public float velocidadMovimiento = 5f;

    private void Start()
    {
        Debug.Log("Active? " + gameObject.activeInHierarchy);
    }

    public void MoverCocinero(Vector3 puntoEnLaBarra)
    {
        if (platosDisponibles.Count > 0)
        {
            GameObject platoAleatorio = platosDisponibles[Random.Range(0, platosDisponibles.Count)];

            // Instancia solo el cocinero (el objeto padre)
            GameObject nuevoCocinero = Instantiate(gameObject, puntoEnLaBarra, Quaternion.identity);

            // Mueve el cocinero hacia la barra
            StartCoroutine(MoverHaciaLaBarra(nuevoCocinero.transform, puntoEnLaBarra));
        }
    }

    IEnumerator MoverHaciaLaBarra(Transform cocineroTransform, Vector3 puntoEnLaBarra)
    {
        while (Vector3.Distance(cocineroTransform.position, puntoEnLaBarra) > 0.1f)
        {
            cocineroTransform.position = Vector3.MoveTowards(cocineroTransform.position, puntoEnLaBarra, velocidadMovimiento * Time.deltaTime);
            yield return null;
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
