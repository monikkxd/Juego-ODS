using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHose : MonoBehaviour
{
    public GameObject waterPrefab; // Prefab del agua que lanzará la manguera
    public Transform spawnPoint; // Punto desde donde se lanzará el agua
    public float launchForce = 10f; // Fuerza con la que se lanzará el agua
    public float launchInterval = 0.1f; // Intervalo entre lanzamientos

    private bool isLaunching = false; // Indica si se está lanzando agua
    private float lastLaunchTime; // Último momento en que se lanzó agua

    void Update()
    {
        // Lanzar agua al presionar y mantener la tecla de espacio
        if (Input.GetKeyDown(KeyCode.R))
        {
            isLaunching = true;
            GetComponent<BoxCollider>().enabled = true;
            LaunchWater();
        }
        // Dejar de lanzar agua al soltar la tecla de espacio
        else if (Input.GetKeyUp(KeyCode.R))
        {
            isLaunching = false;
            GetComponent<BoxCollider>().enabled = false;
        }

        // Si se está lanzando agua y ha pasado el intervalo de lanzamiento, lanzar más agua
        if (isLaunching && Time.time - lastLaunchTime > launchInterval)
        {
            LaunchWater();
            lastLaunchTime = Time.time;
        }
    }

    void LaunchWater()
    {
        // Verificar que exista un prefab de agua y un punto de lanzamiento
        if (waterPrefab != null && spawnPoint != null)
        {
            // Instanciar el prefab del agua en el punto de lanzamiento
            GameObject waterInstance = Instantiate(waterPrefab, spawnPoint.position, spawnPoint.rotation);

            // Obtener el componente Rigidbody del agua
            Rigidbody waterRigidbody = waterInstance.GetComponent<Rigidbody>();

            // Verificar que el componente Rigidbody exista
            if (waterRigidbody != null)
            {
                // Aplicar fuerza al Rigidbody para lanzar el agua hacia adelante
                waterRigidbody.AddForce(spawnPoint.forward * launchForce, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("El prefab del agua no tiene un componente Rigidbody.");
            }
        }
        else
        {
            Debug.LogWarning("Falta asignar el prefab del agua o el punto de lanzamiento.");
        }
    }

    

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);

        if (collider.tag == "Fire")
        {
            Destroy(collider.gameObject);
            Debug.Log("Objeto destruido: " + collider.gameObject.name);
        }
    }
}


