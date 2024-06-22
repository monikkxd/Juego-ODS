using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingState : IbuildingState
{
    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    //SoundFeedback soundFeedback;

    public RemovingState(Grid grid,
                         PreviewSystem previewSystem,
                         GridData floorData,
                         GridData furnitureData,
                         ObjectPlacer objectPlacer)
    //SoundFeedback soundFeedback)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        //this.soundFeedback = soundFeedback;
        previewSystem.StartShowingRemovePreview();
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        int removedObjectId = OnRemove(gridPosition);
        if (removedObjectId != -1)
        {
            Debug.Log($"Edificio destruido con ID: {removedObjectId}");
        }
    }

    public int OnRemove(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        if (furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = furnitureData;
        }
        else if (floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = floorData;
        }

        if (selectedData == null)
        {
            //soundFeedback.PlaySound(SoundType.wrongPlacement);
            return -1;
        }
        else
        {
            //soundFeedback.PlaySound(SoundType.Remove);
            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            if (gameObjectIndex == -1)
                return -1;
            int removedObjectId = selectedData.GetObjectIdAt(gridPosition);
            selectedData.RemoveObjectAt(gridPosition);
            objectPlacer.RemoveObjectAt(gameObjectIndex);
            return removedObjectId;
        }
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = CheckIfSelectionIsValid(gridPosition);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        return !(furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one) &&
            floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one));
    }
}
