using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocinerosSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // El prefab que quieres instanciar
    public List<Transform> targetPositions; // Lista de posiciones a las que puede ir el camarero
    public List<Transform> plateDropPositions; // Lista de posiciones donde los cocineros dejarán los platos
    public float moveSpeed = 5f;      // Velocidad de movimiento del objeto instanciado
    public int numberOfCooks = 3;     // Número de cocineros a instanciar
    public float checkInterval = 10f; // Intervalo de tiempo para verificar las posiciones de plato

    private void Start()
    {
        // Llama a la función SpawnObject al inicio del juego
        SpawnObject();

        // Inicia la rutina para verificar posiciones cada cierto intervalo
        StartCoroutine(VerificarPosicionesDePlato());
    }

    public void SpawnObject()
    {
        // Instancia cocineros en posiciones diferentes
        for (int i = 0; i < Mathf.Min(numberOfCooks, targetPositions.Count); i++)
        {
            // Instancia el prefab en la posición actual del Spawner
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // Obtén la posición de destino en la barra para este cocinero
            Transform plateDropPosition = plateDropPositions[i % plateDropPositions.Count];

            // Obtén la posición de destino general para este cocinero
            Transform targetPosition = targetPositions[i];

            // Configura las posiciones de destino para el cocinero
            spawnedObject.GetComponent<Cocinero>().SetTargetPositions(targetPosition, plateDropPosition);

            // Mueve el objeto instanciado hacia la posición correspondiente
            StartCoroutine(MoveObjectToTarget(spawnedObject, targetPosition));
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

    IEnumerator VerificarPosicionesDePlato()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);

            // Contar cuántos platos faltan en todas las posiciones de plato
            int platesNeeded = 0;
            foreach (Transform plateDropPos in plateDropPositions)
            {
                PlatoDetector detector = plateDropPos.GetComponentInChildren<PlatoDetector>();
                if (detector != null && !detector.TienePlato())
                {
                    platesNeeded++;
                }
            }

            // Instanciar cocineros adicionales para reponer los platos faltantes
            for (int i = 0; i < platesNeeded; i++)
            {
                Transform newPlateDropPosition = GetNextAvailablePlateDropPosition();
                Transform newTargetPosition = GetNextAvailableTargetPosition();

                if (newPlateDropPosition != null && newTargetPosition != null)
                {
                    // Instancia un nuevo cocinero
                    GameObject newCook = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

                    // Configura las posiciones de destino para el nuevo cocinero
                    newCook.GetComponent<Cocinero>().SetTargetPositions(newTargetPosition, newPlateDropPosition);

                    // Mueve el nuevo cocinero hacia la posición correspondiente
                    StartCoroutine(MoveObjectToTarget(newCook, newTargetPosition));
                }
            }
        }
    }

    private Transform GetNextAvailablePlateDropPosition()
    {
        foreach (Transform plateDropPos in plateDropPositions)
        {
            PlatoDetector detector = plateDropPos.GetComponentInChildren<PlatoDetector>();
            if (detector != null && !detector.TienePlato())
            {
                return plateDropPos;
            }
        }
        return null;
    }

    private Transform GetNextAvailableTargetPosition()
    {
        foreach (Transform targetPos in targetPositions)
        {
            // Verificar si el targetPosition está libre
            if (!targetPos.GetComponentInChildren<Cocinero>())
            {
                return targetPos;
            }
        }
        return null;
    }
}
