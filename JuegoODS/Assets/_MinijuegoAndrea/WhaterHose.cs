using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHose : MonoBehaviour
{
    public GameObject waterPrefab; // Prefab del agua que lanzar� la manguera
    public Transform spawnPoint; // Punto desde donde se lanzar� el agua
    public float launchForce = 10f; // Fuerza con la que se lanzar� el agua
    public float launchInterval = 0.1f; // Intervalo entre lanzamientos

    private bool isLaunching = false; // Indica si se est� lanzando agua
    private float lastLaunchTime; // �ltimo momento en que se lanz� agua

    void Update()
    {
        // Lanzar agua al presionar y mantener la tecla de espacio
        if (Input.GetKeyDown(KeyCode.E))
        {
            isLaunching = true;
            LaunchWater();
        }
        // Dejar de lanzar agua al soltar la tecla de espacio
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isLaunching = false;
        }

        // Si se est� lanzando agua y ha pasado el intervalo de lanzamiento, lanzar m�s agua
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

    // Cuando el agua colisiona con otro objeto
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado tiene que desaparecer
        if (collision.gameObject.CompareTag("Fire"))
        {
            // Destruir el objeto que colision� con el agua
            Destroy(collision.gameObject);
            Debug.Log("Objeto destruido: " + collision.gameObject.name);
        }
    }
}


