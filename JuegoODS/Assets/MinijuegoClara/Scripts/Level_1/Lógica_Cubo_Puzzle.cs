using System.Collections;
using UnityEngine;

public class Lógica_Cubo_Puzzle : MonoBehaviour
{
    [Header("Almacen Cubos")]
    public GameObject rubikCube;

    [Header("Cubos Victoria")]
    public GameObject cubeOfVictory1;
    public GameObject cubeOfVictory2;

    [Header("Color Victoria")]
    public Color victoryColor = Color.green;

    [Header("Velocidad Rotación")]
    public float rotationSpeed = 5f;

    private bool isRotating = false;
    private bool isTopSelected = true;
    private bool isBottomSelected = false;
    private bool isLeftSelected = false;
    private bool isRightSelected = false;
    private bool isFrontSelected = false;
    private bool isBackSelected = false;

    private Color originalColor;

    

    void Start()
    {
        cubeOfVictory1.GetComponent<Renderer>().material.color = victoryColor;
        cubeOfVictory2.GetComponent<Renderer>().material.color = victoryColor;

        SelectTop();
        originalColor = rubikCube.GetComponent<Renderer>().material.color;

        
    }

    

    void Update()
    {
        if (isRotating)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectTop();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SelectBottom();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SelectLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SelectRight();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectFront();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SelectBack();
        }

        if (isTopSelected || isBottomSelected)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                RotateSelectedPart(Vector3.up, 90f);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RotateSelectedPart(Vector3.up, -90f);
            }
        }
        else if (isLeftSelected || isRightSelected)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                RotateSelectedPart(Vector3.right, 90f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                RotateSelectedPart(Vector3.right, -90f);
            }
        }
        else if (isFrontSelected || isBackSelected)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                RotateSelectedPart(Vector3.forward, 90f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                RotateSelectedPart(Vector3.forward, -90f);
            }
        }

       
    }

    

    void SelectTop()
    {
        isTopSelected = true;
        isBottomSelected = false;
        isLeftSelected = false;
        isRightSelected = false;
        isFrontSelected = false;
        isBackSelected = false;
        SetCubeColor(Color.red);
    }

    void SelectBottom()
    {
        isTopSelected = false;
        isBottomSelected = true;
        isLeftSelected = false;
        isRightSelected = false;
        isFrontSelected = false;
        isBackSelected = false;
        SetCubeColor(Color.red);
    }

    void SelectLeft()
    {
        isTopSelected = false;
        isBottomSelected = false;
        isLeftSelected = true;
        isRightSelected = false;
        isFrontSelected = false;
        isBackSelected = false;
        SetCubeColor(Color.red);
    }

    void SelectRight()
    {
        isTopSelected = false;
        isBottomSelected = false;
        isLeftSelected = false;
        isRightSelected = true;
        isFrontSelected = false;
        isBackSelected = false;
        SetCubeColor(Color.red);
    }

    void SelectFront()
    {
        isTopSelected = false;
        isBottomSelected = false;
        isLeftSelected = false;
        isRightSelected = false;
        isFrontSelected = true;
        isBackSelected = false;
        SetCubeColor(Color.red);
    }

    void SelectBack()
    {
        isTopSelected = false;
        isBottomSelected = false;
        isLeftSelected = false;
        isRightSelected = false;
        isFrontSelected = false;
        isBackSelected = true;
        SetCubeColor(Color.red);
    }

    void SetCubeColor(Color color)
    {
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();

        foreach (Transform childCube in childCubes)
        {
            if (childCube != rubikCube.transform)
            {
                Renderer cubeRenderer = childCube.GetComponent<Renderer>();

                if (childCube.gameObject != cubeOfVictory1 && childCube.gameObject != cubeOfVictory2)
                {
                    cubeRenderer.material.color =
                        isTopSelected ? (childCube.position.y > rubikCube.transform.position.y ? color : originalColor) :
                        isBottomSelected ? (childCube.position.y < rubikCube.transform.position.y ? color : originalColor) :
                        isLeftSelected ? (childCube.position.x < rubikCube.transform.position.x ? color : originalColor) :
                        isRightSelected ? (childCube.position.x > rubikCube.transform.position.x ? color : originalColor) :
                        isFrontSelected ? (childCube.position.z > rubikCube.transform.position.z ? color : originalColor) :
                        isBackSelected ? (childCube.position.z < rubikCube.transform.position.z ? color : originalColor) :
                        originalColor;
                }
            }
        }
    }

    void RotateSelectedPart(Vector3 axis, float angle)
    {
        if ((isTopSelected || isBottomSelected) && axis != Vector3.up)
        {
            return;
        }
        else if ((isLeftSelected || isRightSelected) && axis != Vector3.right)
        {
            return;
        }
        else if ((isFrontSelected || isBackSelected) && axis != Vector3.forward)
        {
            return;
        }

        isRotating = true;

        Transform[] selectedCubes = isTopSelected ? GetTopCubes() :
            isBottomSelected ? GetBottomCubes() :
            isLeftSelected ? GetLeftCubes() :
            isRightSelected ? GetRightCubes() :
            isFrontSelected ? GetFrontCubes() :
            isBackSelected ? GetBackCubes() :
            new Transform[0];

        Vector3 pivot = GetPivot(selectedCubes);

        StartCoroutine(RotateOverTime(selectedCubes, pivot, axis, angle, rotationSpeed, () =>
        {
            isRotating = false;
        }));
    }

    Transform[] GetTopCubes()
    {
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.y > rubikCube.transform.position.y);
    }

    Transform[] GetBottomCubes()
    {
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.y < rubikCube.transform.position.y);
    }

    Transform[] GetLeftCubes()
    {
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.x < rubikCube.transform.position.x);
    }

    Transform[] GetRightCubes()
    {
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.x > rubikCube.transform.position.x);
    }

    Transform[] GetFrontCubes()
    {
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.z > rubikCube.transform.position.z);
    }

    Transform[] GetBackCubes()
    {
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.z < rubikCube.transform.position.z);
    }

    Vector3 GetPivot(Transform[] cubes)
    {
        Vector3 center = Vector3.zero;
        foreach (Transform cube in cubes)
        {
            center += cube.position;
        }
        center /= cubes.Length;
        return center;
    }

    IEnumerator RotateOverTime(Transform[] targetTransforms, Vector3 pivot, Vector3 axis, float angle, float speed, System.Action onRotationComplete)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * speed;

            Quaternion deltaRotation = Quaternion.Euler(axis * angle * Time.deltaTime * speed);
            foreach (Transform targetTransform in targetTransforms)
            {
                Vector3 offset = targetTransform.position - pivot;
                targetTransform.position = pivot + deltaRotation * offset;
                targetTransform.rotation *= deltaRotation;
            }

            yield return null;
        }

        onRotationComplete?.Invoke();
    }

    
}
