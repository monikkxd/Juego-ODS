using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab que queremos spawnear
    public GameObject prefabToSpawn;

    // Intervalo de tiempo en segundos entre cada spawn
    public float spawnInterval = 2f;

    // Fuerza con la que se expulsa el prefab hacia adelante
    public float spawnForce = 10f;

    // Variable para almacenar la referencia al coroutine
    private Coroutine spawnCoroutine;

    // Método para iniciar el spawneo continuo
    void Start()
    {
        // Inicia el coroutine de spawneo
        spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    // Coroutine que se ejecuta continuamente para spawnear el prefab
    IEnumerator SpawnRoutine()
    {
        // Loop infinito para spawnear continuamente
        while (true)
        {
            // Instancia el prefab en la posición y rotación del spawner
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation);

            // Obtén el Rigidbody del prefab para aplicar la fuerza
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Aplica una fuerza hacia adelante
                rb.AddForce(transform.forward * spawnForce, ForceMode.Impulse);
            }

            // Espera el intervalo de tiempo especificado antes de spawnear el siguiente prefab
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Método para detener el spawneo
    public void StopSpawning()
    {
        // Detiene el coroutine de spawneo
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }
}


