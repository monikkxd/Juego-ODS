using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject cellPrefab;
    public int rows = 5;
    public int columns = 5;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject cell = Instantiate(cellPrefab, transform);
            }
        }
    }
}
