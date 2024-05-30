using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocinerosSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public List<Transform> targetPositions;
    public List<Transform> plateDropPositions;
    public float moveSpeed = 5f;
    public int numberOfCooks = 3;
    public float checkInterval = 10f;

    private void Start()
    {
        SpawnObject();
        StartCoroutine(VerificarPosicionesDePlato());
    }

    public void SpawnObject()
    {
        for (int i = 0; i < Mathf.Min(numberOfCooks, targetPositions.Count); i++)
        {
            GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            Transform plateDropPosition = plateDropPositions[i % plateDropPositions.Count];
            Transform targetPosition = targetPositions[i];
            spawnedObject.GetComponent<Cocinero>().SetTargetPositions(targetPosition, plateDropPosition);
            StartCoroutine(MoveObjectToTarget(spawnedObject, targetPosition));
        }
    }

    IEnumerator MoveObjectToTarget(GameObject objToMove, Transform target)
    {
        while (Vector3.Distance(objToMove.transform.position, target.position) > 0.1f)
        {
            objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Objeto ha llegado al objeto objetivo en " + target.name);
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveObjectToSpawn(objToMove));
    }

    IEnumerator MoveObjectToSpawn(GameObject objToMove)
    {
        while (Vector3.Distance(objToMove.transform.position, transform.position) > 0.1f)
        {
            objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Objeto ha vuelto al punto de spawn");
        Destroy(objToMove);
    }

    IEnumerator VerificarPosicionesDePlato()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);

            int platesNeeded = 0;
            foreach (Transform plateDropPos in plateDropPositions)
            {
                PlatoDetector detector = plateDropPos.GetComponentInChildren<PlatoDetector>();
                if (detector != null && !detector.TienePlato())
                {
                    platesNeeded++;
                }
            }

            for (int i = 0; i < platesNeeded; i++)
            {
                Transform newPlateDropPosition = GetNextAvailablePlateDropPosition();
                Transform newTargetPosition = GetNextAvailableTargetPosition();

                if (newPlateDropPosition != null && newTargetPosition != null)
                {
                    GameObject newCook = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
                    newCook.GetComponent<Cocinero>().SetTargetPositions(newTargetPosition, newPlateDropPosition);
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
            if (!targetPos.GetComponentInChildren<Cocinero>())
            {
                return targetPos;
            }
        }
        return null;
    }
}
