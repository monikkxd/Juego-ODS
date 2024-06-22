using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private GameObject colegioConstruido;
    [SerializeField]
    private GameObject bibliotecaConstruido;
    [SerializeField]
    private GameObject ayuntamientoConstruido;
    [SerializeField]
    private GameObject hospitalConstruido;
    [SerializeField]
    private GameObject tiendaConstruida;
    [SerializeField]
    private GameObject viviendasContruida;
    [SerializeField]
    private GameObject centroComercialConstruido;
    [SerializeField]
    private GameObject comisariaContruida;
    [SerializeField]
    private GameObject parqueContruido;
    [SerializeField]
    private GameObject jardínConstruido;
    [SerializeField]
    private GameObject puestoLimonadaConstruido;
    [SerializeField]
    private GameObject carreterasContruido;
    [SerializeField]
    private GameObject parqueInfantilConstruido;
    [SerializeField]
    private GameObject merenderoConstruido;


    [SerializeField]
    private Animator animatorListasTareas;

    private int activatedObjectsCount = 0;

    [Header("Tuto Mid-Game")]
    public GameObject tutoObject;
    public Animator tutoAnimator;

    public GameObject alerta;

    private List<int> destroyedBuildingIDs = new List<int>();  

    private void Start()
    {
        gridVisualization.SetActive(false);
        floorData = new GridData();
        furnitureData = new GridData();
        animatorListasTareas.enabled = false;

     
    }

    public void StartPlacement(int ID)
    {
        if (destroyedBuildingIDs.Count > 0 && ID > 0 && !destroyedBuildingIDs.Contains(ID))
        {
            StartCoroutine(ActivarDesactivarObjecto());
            Debug.LogWarning("Debes reconstruir los edificios destruidos antes de colocar otros edificios.");
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

        if (buildingState is PlacementState placementState)
        {
            int objectId = placementState.ID;
            ActivateGameObjectById(objectId);

            if (objectId > 0 && destroyedBuildingIDs.Contains(objectId))
            {
                destroyedBuildingIDs.Remove(objectId);
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
            if (removedObjectId > 0)
            {
                destroyedBuildingIDs.Add(removedObjectId);
                Debug.Log($"Edificio destruido con ID: {removedObjectId}");
            }
        }
    }

    private void ActivateGameObjectById(int ID)
    {
        bool objectActivated = false;

        switch (ID)
        {
            case -1:
                if (carreterasContruido != null && !carreterasContruido.activeSelf)
                {
                    carreterasContruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case -2:
                if (carreterasContruido != null && !carreterasContruido.activeSelf)
                {
                    carreterasContruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 1:
                if (colegioConstruido != null && !colegioConstruido.activeSelf)
                {
                    colegioConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 2:
                if (bibliotecaConstruido != null && !bibliotecaConstruido.activeSelf)
                {
                    bibliotecaConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 3:
                if (ayuntamientoConstruido != null && !ayuntamientoConstruido.activeSelf)
                {
                    ayuntamientoConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 4:
                if (hospitalConstruido != null && !hospitalConstruido.activeSelf)
                {
                    hospitalConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 7:
                if (tiendaConstruida != null && !tiendaConstruida.activeSelf)
                {
                    tiendaConstruida.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 8:
                if (viviendasContruida != null && !viviendasContruida.activeSelf)
                {
                    viviendasContruida.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 9:
                if (centroComercialConstruido != null && !centroComercialConstruido.activeSelf)
                {
                    centroComercialConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 10:
                if (comisariaContruida != null && !comisariaContruida.activeSelf)
                {
                    comisariaContruida.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 11:
                if (parqueContruido != null && !parqueContruido.activeSelf)
                {
                    parqueContruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 12:
                if (parqueInfantilConstruido != null && !parqueInfantilConstruido.activeSelf)
                {
                    parqueInfantilConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 13:
                if (jardínConstruido != null && !jardínConstruido.activeSelf)
                {
                    jardínConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 14:
                if (merenderoConstruido != null && !merenderoConstruido.activeSelf)
                {
                    merenderoConstruido.SetActive(true);
                    objectActivated = true;
                }
                break;
            case 15:
                if (puestoLimonadaConstruido != null && !puestoLimonadaConstruido.activeSelf)
                {
                    puestoLimonadaConstruido.SetActive(true);
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
            if (activatedObjectsCount == 4 && animatorListasTareas != null)
            {
                animatorListasTareas.enabled = true;
                tutoObject.SetActive(true);
                tutoAnimator.Play("TutoDestruir&Flechas");
            }
            else if(activatedObjectsCount == 8 && animatorListasTareas != null)
            {
                animatorListasTareas.Play("CambioTareas2_Animator");
            }
            else if(activatedObjectsCount == 11 && animatorListasTareas != null)
            {
                animatorListasTareas.Play("CambioTareas3_Animator");
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
    IEnumerator ActivarDesactivarObjecto()
    {
        alerta.SetActive(true);

        yield return new WaitForSeconds(2f);

        alerta.SetActive(false);
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