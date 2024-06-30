using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndreaTutoManager : MonoBehaviour
{
    // Public variable to link the GameObject from the Unity Inspector
    public GameObject targetObject;


    // Time duration for which the object will stay active
    public float activeDuration = 7.0f;

    public WaterHose waterHose;
    public ThirdPersonController ThirdPersonController;
    public CameraController cameraController;

    private void Start()
    {
        ThirdPersonController.enabled = false;
        waterHose.enabled = false;
        cameraController.enabled = false;
        targetObject.SetActive(true);

        Invoke("ActivateCharacter", 4);
    }

    public void ActivateCharacter()
    {
        ThirdPersonController.enabled = true;
        waterHose.enabled = true;
        cameraController.enabled = true;
        targetObject.SetActive(false);
    }
}

