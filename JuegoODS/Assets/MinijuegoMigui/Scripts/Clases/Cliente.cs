using UnityEngine;
using System;
using System.Collections;

public class Cliente : MonoBehaviour
{
    public float velocidadMovimiento = 3f;
    public Mesa mesaAsignada;

    public void MoverCliente(Vector3 posicionDeInstancia, Mesa mesaAsignada)
    {
        this.mesaAsignada = mesaAsignada;
        
        GameObject nuevoCliente = Instantiate(gameObject, posicionDeInstancia, Quaternion.identity);
       
        StartCoroutine(MoverHaciaLaMesa(nuevoCliente.transform, mesaAsignada.transform.position));
    }

    IEnumerator MoverHaciaLaMesa(Transform clienteTransform, Vector3 posicionMesa)
    {
        while (Vector3.Distance(clienteTransform.position, posicionMesa) > 0.1f)
        {
            clienteTransform.position = Vector3.MoveTowards(clienteTransform.position, posicionMesa, velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
        
    }

   
}
