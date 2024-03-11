using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocinerosSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // El prefab que quieres instanciar
    public List<Transform> targetPositions; // Lista de posiciones a las que puede ir el camarero
    public float moveSpeed = 5f;      // Velocidad de movimiento del objeto instanciado

    void Start()
    {
        // Llama a la función SpawnObject al inicio del juego
        SpawnObject();
    }

    public void SpawnObject()
    {
        // Instancia 3 cocineros en posiciones diferentes
        for (int i = 0; i < 3; i++)
        {
            // Calcula una posición aleatoria de la lista
            int randomIndex = Random.Range(0, targetPositions.Count);
            Transform randomTarget = targetPositions[randomIndex];

            // Instancia el prefab en la posición actual del Spawner
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // Mueve el objeto instanciado hacia la posición aleatoria
            StartCoroutine(MoveObjectToTarget(spawnedObject, randomTarget));
        }
    }

    IEnumerator MoveObjectToTarget(GameObject objToMove, Transform target)
    {
        while (Vector3.Distance(objToMove.transform.position, target.position) > 0.1f)
        {
            // Mueve el objeto hacia la posición objetivo a la velocidad especificada
            objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, target.position, moveSpeed * Time.deltaTime);

            // Espera un frame antes de la siguiente iteración
            yield return null;
        }

        // El objeto ha llegado al objeto objetivo
        Debug.Log("Objeto ha llegado al objeto objetivo en " + target.name);

        // Espera 2 segundos antes de volver al punto de spawn
        yield return new WaitForSeconds(2f);

        // Vuelve al punto de spawn
        StartCoroutine(MoveObjectToSpawn(objToMove));
    }

    IEnumerator MoveObjectToSpawn(GameObject objToMove)
    {
        while (Vector3.Distance(objToMove.transform.position, transform.position) > 0.1f)
        {
            // Mueve el objeto hacia el punto de spawn a la velocidad especificada
            objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, transform.position, moveSpeed * Time.deltaTime);

            // Espera un frame antes de la siguiente iteración
            yield return null;
        }

        // El objeto ha vuelto al punto de spawn
        Debug.Log("Objeto ha vuelto al punto de spawn");

        // Destruye el objeto
        Destroy(objToMove);
    }
}
