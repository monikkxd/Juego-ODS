using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioTutoManager : MonoBehaviour
{
    // Public variable to link the GameObject from the Unity Inspector
    public GameObject targetObject;

    // Time duration for which the object will stay active
    public float activeDuration = 7.0f;

    private void Start()
    {
        Time.timeScale = 0;
        // Start the coroutine that handles the activation and deactivation
        //StartCoroutine(ActivateAndDeactivate());

        targetObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Time.timeScale = 1;

            targetObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            SaltarNivel();
        }
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

    public void SaltarNivel()
    {
        SceneManager.LoadScene("SelecciónNivel");
        SelectorNivel.monicaCompletado = true;
    }
}

