using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndicator, cellIndicator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Grid grid;
    [SerializeField] private ObjectsDatabaseSO dataBase;
    private int selectedObjectIndex = -1;

    [SerializeField] private GameObject gridVisualization;

    private GridData floorData, furnitureData;

    private Renderer previewRenderer;

    private List<GameObject> placedGameObjects = new();

    private void Start()
    {
        StopPlacement();
        floorData = new GridData();
        furnitureData = new();
        previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }
    public void StartPlacement(int ID)
    {
        StopPlacement();
        selectedObjectIndex = dataBase.objectsData.FindIndex(data => data.ID == ID);
        if(selectedObjectIndex < 0)
        {
            Debug.LogError($"No ID found {ID}");
            return;
        }
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if(inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        bool placemenentValidity = checkPlacementValidity(gridPosition, selectedObjectIndex);
        if (placemenentValidity == false)
            return;

        GameObject newObject = Instantiate(dataBase.objectsData[selectedObjectIndex].Prefab);
        newObject.transform.position = grid.CellToWorld(gridPosition);
        placedGameObjects.Add(newObject);
        GridData selectedData = dataBase.objectsData[selectedObjectIndex].ID == 0 ?
            floorData :
            furnitureData;
        selectedData.AddObjectAt(gridPosition,
                                 dataBase.objectsData[selectedObjectIndex].Size,
                                 dataBase.objectsData[selectedObjectIndex].ID,
                                 placedGameObjects.Count - 1);


    }

    private bool checkPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
       GridData selectedData = dataBase.objectsData[selectedObjectIndex].ID == 0 ? 
            floorData : 
            furnitureData;

        return selectedData.CanPlaceObejctAt(gridPosition,
                                             dataBase.objectsData[selectedObjectIndex].Size);


    }

    private void StopPlacement()
    {
        selectedObjectIndex = -1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
    }

    private void Update()
    {
        if(selectedObjectIndex < 0)
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        bool placemenentValidity = checkPlacementValidity(gridPosition, selectedObjectIndex);
        previewRenderer.material.color = placemenentValidity ? Color.white : Color.red;


        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
