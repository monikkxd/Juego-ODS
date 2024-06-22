using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    [Space]
    [SerializeField]
    private Grid grid;

    [Header("Base de Datos Edificios")]
    [SerializeField]
    private ObjectsDatabaseSO database;
    [Space]
    [SerializeField]
    private GameObject gridVisualization;

    [SerializeField]
    private AudioClip correctPlacementClip, wrongPlacementClip;
    [SerializeField]
    private AudioSource source;

    private GridData floorData, furnitureData;

    [SerializeField]
    private PreviewSystem preview;

    private Vector3Int lastDetectedPosition = Vector3Int.zero;

    [SerializeField]
    private ObjectPlacer objectPlacer;

    IbuildingState buildingState;

    [Header("Edificios Construidos")]
    [SerializeField]
    private GameObject gameObject1;
    [SerializeField]
    private GameObject gameObject2;
    [SerializeField]
    private GameObject gameObject3;
    [SerializeField]
    private GameObject gameObject4;
    [SerializeField]
    private GameObject gameObject5;
    [SerializeField]
    private GameObject gameObject6;
    [SerializeField]
    private GameObject gameObject7;
    [SerializeField]
    private GameObject gameObject8;

    [SerializeField]
    private Animator animator;

    private int activatedObjectsCount = 0;

    [Header("Tuto Mid-Game")]
    public GameObject tutoObject;
    public Animator tutoAnimator;

    private int destroyedBuildingID = -1;  // Almacena el ID del edificio destruido

    private void Start()
    {
        gridVisualization.SetActive(false);
        floorData = new GridData();
        furnitureData = new GridData();
        animator.enabled = false;
    }

    public void StartPlacement(int ID)
    {
        // Si hay un edificio destruido, solo permite la colocación del mismo edificio
        if (destroyedBuildingID != -1 && ID != destroyedBuildingID)
        {
            Debug.LogWarning("Debes reconstruir el edificio destruido antes de colocar otros edificios.");
            return;
        }

        StopPlacement();
        gridVisualization.SetActive(true);
        buildingState = new PlacementState(ID,
                                           grid,
                                           preview,
                                           database,
                                           floorData,
                                           furnitureData,
                                           objectPlacer);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    public void StartRemoving()
    {
        StopPlacement();
        gridVisualization.SetActive(true);
        buildingState = new RemovingState(grid, preview, floorData, furnitureData, objectPlacer);
        inputManager.OnClicked += RemoveStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        buildingState.OnAction(gridPosition);

        // Obtención del ID del objeto que se está colocando
        if (buildingState is PlacementState placementState)
        {
            int objectId = placementState.ID;
            ActivateGameObjectById(objectId);

            // Si el edificio colocado es el mismo que fue destruido, resetea destroyedBuildingID
            if (destroyedBuildingID == objectId)
            {
                destroyedBuildingID = -1;
            }
        }
    }

    private void RemoveStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        if (buildingState is RemovingState removingState)
        {
            int removedObjectId = removingState.OnRemove(gridPosition);
            if (removedObjectId != -1)
            {
                destroyedBuildingID = removedObjectId;
                Debug.Log($"Edificio destruido con ID: {destroyedBuildingID}");
            }
        }
    }

    private void ActivateGameObjectById(int ID)
    {
        bool objectActivated = false;

        switch (ID)
        {
            case 1:
                if (gameObject1 != null && !gameObject1.activeSelf)
                {
                    gameObject1.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 2:
                if (gameObject2 != null && !gameObject2.activeSelf)
                {
                    gameObject2.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 3:
                if (gameObject3 != null && !gameObject3.activeSelf)
                {
                    gameObject3.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 4:
                if (gameObject4 != null && !gameObject4.activeSelf)
                {
                    gameObject4.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 7:
                if (gameObject5 != null && !gameObject5.activeSelf)
                {
                    gameObject5.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 8:
                if (gameObject6 != null && !gameObject6.activeSelf)
                {
                    gameObject6.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 9:
                if (gameObject7 != null && !gameObject7.activeSelf)
                {
                    gameObject7.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 10:
                if (gameObject8 != null && !gameObject8.activeSelf)
                {
                    gameObject8.SetActive(true);
                    objectActivated = true;
                }
                break;
            default:
                Debug.LogWarning($"No GameObject assigned for ID {ID}");
                break;
        }

        if (objectActivated)
        {
            activatedObjectsCount++;
            if (activatedObjectsCount == 4 && animator != null)
            {
                animator.enabled = true;
                tutoObject.SetActive(true);
                tutoAnimator.Play("TutoDestruir&Flechas");
            }
        }
    }

    private void StopPlacement()
    {
        //soundFeedback.PlaySound(SoundType.Click);
        if (buildingState == null)
            return;
        gridVisualization.SetActive(false);
        buildingState.EndState();
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
        lastDetectedPosition = Vector3Int.zero;
        buildingState = null;
    }

    private void Update()
    {
        if (buildingState == null)
            return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        if (lastDetectedPosition != gridPosition)
        {
            buildingState.UpdateState(gridPosition);
            lastDetectedPosition = gridPosition;
        }
    }
}
