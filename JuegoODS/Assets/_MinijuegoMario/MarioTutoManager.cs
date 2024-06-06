using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioTutoManager : MonoBehaviour
{
    // Public variable to link the GameObject from the Unity Inspector
    public GameObject targetObject;

    // Time duration for which the object will stay active
    public float activeDuration = 7.0f;

    private void Start()
    {
        // Start the coroutine that handles the activation and deactivation
        StartCoroutine(ActivateAndDeactivate());
    }

    private IEnumerator ActivateAndDeactivate()
    {
        // Activate the target GameObject
        targetObject.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(activeDuration);

        // Deactivate the target GameObject
        targetObject.SetActive(false);
    }
}

