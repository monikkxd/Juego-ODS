using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocinero : MonoBehaviour
{
    public List<GameObject> platosDisponibles;
    public Transform holder;
    public string barraTag = "Barra";
    public LayerMask barraLayer;

    bool llevandoPlato = true;
    GameObject platoActual;
    Transform barra;

    void Start()
    {
        barra = GameObject.FindWithTag(barraTag)?.transform; // Busca el objeto de la barra por tag

        if (barra == null)
        {
            Debug.LogError("No se pudo encontrar la barra. Asegúrate de que tenga el tag correcto.");
        }

        if (llevandoPlato)
        {
            LlevarPlatoInicial();
        }
    }

    void Update()
    {
        // Si el camarero está llevando un plato y colisiona con la barra, lo deja
        if (llevandoPlato && DetectarColisionConBarra())
        {
            DejarPlatoEnBarra();
        }
    }

    void LlevarPlatoInicial()
    {
        // Selecciona aleatoriamente un prefab de plato de la lista
        GameObject platoPrefabSeleccionado = platosDisponibles[Random.Range(0, platosDisponibles.Count)];

        // Instancia el plato en la posición del "holder"
        platoActual = Instantiate(platoPrefabSeleccionado, holder.position, Quaternion.identity);
        platoActual.transform.SetParent(holder);  // Hace que el plato sea hijo del "holder"
    }

    bool DetectarColisionConBarra()
    {
        // Si la referencia a la barra no es nula
        if (barra != null)
        {
            // Obtén todos los colliders en el objeto del camarero que colisionan con la capa de la barra
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, barraLayer);

            // Si hay al menos un collider en la capa de la barra, devuelve true
            return colliders.Length > 0;
        }

        return false;
    }

    void DejarPlatoEnBarra()
    {
        llevandoPlato = false;

        // Encuentra la posición más cercana entre los hijos de la barra
        Vector3 posicionMasCercana = EncontrarPosicionMasCercanaEnBarra();

        // Cambia la jerarquía y posición del plato para que sea hijo de la barra
        platoActual.transform.SetParent(null);  // Desvincula el plato del "holder"
        platoActual.transform.position = posicionMasCercana;  // Coloca el plato en la posición más cercana de la barra
    }

    Vector3 EncontrarPosicionMasCercanaEnBarra()
    {
        Transform posicionMasCercana = null;
        float distanciaMinima = float.MaxValue;

        // Itera a través de las posiciones de la barra para encontrar la más cercana al camarero
        for (int i = 0; i < barra.childCount; i++)
        {
            Transform posicionActual = barra.GetChild(i);
            Vector3 direccion = posicionActual.position - transform.position;
            float distanciaActual = direccion.magnitude;

            // Si la posición actual es más cercana, actualiza la posición más cercana
            if (distanciaActual < distanciaMinima)
            {
                posicionMasCercana = posicionActual;
                distanciaMinima = distanciaActual;
            }
        }

        // Si se encontró una posición cercana, devuelve su posición
        if (posicionMasCercana != null)
        {
            return posicionMasCercana.position;
        }

        // Si no hay hijos, coloca el plato en la posición de la barra.
        return barra.position;
    }
}
