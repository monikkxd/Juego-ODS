using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Cocinero : MonoBehaviour
{

    public List<GameObject> platosDisponibles;  
    public Transform barraDePlatos;  
    public float velocidadMovimiento = 5f;

    private void Start()
    {

        Debug.Log("Active? " + gameObject.activeInHierarchy);

    }
    public void MoverCocinero(Vector3 posicionDeInstancia)
    {
        if (platosDisponibles.Count > 0)
        {
            GameObject platoAleatorio = platosDisponibles[Random.Range(0, platosDisponibles.Count)];
            
            GameObject nuevoCocinero = Instantiate(gameObject, posicionDeInstancia, Quaternion.identity);
            // Instancia el plato en la posición del cocinero
            GameObject nuevoPlato = Instantiate(platoAleatorio, transform.position, Quaternion.identity);
            nuevoPlato.transform.parent = nuevoCocinero.transform;  
            
            StartCoroutine(MoverHaciaLaBarra(this.gameObject.transform));
        }
    }

    IEnumerator MoverHaciaLaBarra(Transform cocineroTransform)
    {
        Transform puntoEnLaBarra = ObtenerPuntoAleatorioEnLaBarra();
        while (Vector3.Distance(cocineroTransform.position, puntoEnLaBarra.position) > 0.1f)
        {
            cocineroTransform.position = Vector3.MoveTowards(cocineroTransform.position, puntoEnLaBarra.position, velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
        // Deja el plato en la barra
        DejarPlatoEnBarra(cocineroTransform);
        
        Destroy(cocineroTransform.gameObject);
    }

    Transform ObtenerPuntoAleatorioEnLaBarra()
    {
        
        int indiceAleatorio = Random.Range(0, barraDePlatos.childCount);
        return barraDePlatos.GetChild(indiceAleatorio);
    }

    void DejarPlatoEnBarra(Transform cocineroTransform)
    {
        
        cocineroTransform.GetChild(0).position = cocineroTransform.position;
        cocineroTransform.GetChild(0).parent = null;  
        
    }
}
