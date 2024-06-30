using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAgua : MonoBehaviour
{
    public GameObject prefab; // El prefab que se instanciará
    public float spawnInterval = 1.0f; // Intervalo entre cada instancia
    public float launchForce = 10.0f; // Fuerza con la que se lanzará el prefab hacia adelante
    private bool spawn = true;

    private void Start()
    {
        // Iniciar la coroutine que instancia el prefab continuamente
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (spawn==true)
        {
            // Instanciar el prefab en la posición y rotación del spawner
            Debug.Log("instanciatee");
            GameObject spawnedObject = Instantiate(prefab, transform.position, transform.rotation);

            // Obtener el componente Rigidbody del prefab
            Debug.Log("rb");
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();

            // Si el prefab tiene un Rigidbody, aplicarle una fuerza hacia adelante
            if (rb != null)
            {
                
                rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
                Debug.Log("if");
            }

            // Esperar el intervalo especificado antes de instanciar el siguiente prefab
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}



