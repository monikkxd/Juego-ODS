using System.Collections;
using UnityEngine;

public class Lógica_Cubo_Puzzle : MonoBehaviour
{
    public GameObject rubikCube; // Asigna el objeto vacío que contiene los 8 cubos
    public GameObject cubeOfVictory1; // Asigna el primer cubo de la victoria
    
    public GameObject cubeOfVictory2; // Asigna el segundo cubo de la victoria
    
    public Color victoryColor = Color.green; // Color para los cubos de la victoria
    public float rotationSpeed = 5f; // Velocidad de rotación

    private bool isRotating = false; // Variable de estado para indicar si se está realizando una rotación
    private bool isTopSelected = true; // Variable de estado para indicar si la parte superior está seleccionada
    private bool isBottomSelected = false; // Variable de estado para indicar si la parte inferior está seleccionada
    private bool isLeftSelected = false; // Variable de estado para indicar si la parte izquierda está seleccionada
    private bool isRightSelected = false; // Variable de estado para indicar si la parte derecha está seleccionada
    private bool isFrontSelected = false; // Variable de estado para indicar si la parte frontal está seleccionada
    private bool isBackSelected = false; // Variable de estado para indicar si la parte trasera está seleccionada

    private Color originalColor; // Color original de los cubos

    private Vector3 victoryPosition1; // Posición de victoria del primer cubo
    private Vector3 victoryPosition2; // Posición de victoria del segundo cubo

    public Transform[] victoryPositions; // Posiciones de victoria

    // Resto de las variables...

    void Start()
    {
        // Asignar el color de victoria a los cubos desde el principio
        cubeOfVictory1.GetComponent<Renderer>().material.color = victoryColor;
        cubeOfVictory2.GetComponent<Renderer>().material.color = victoryColor;

        // Iniciar seleccionando la parte superior y almacenar el color original
        SelectTop();
        originalColor = rubikCube.GetComponent<Renderer>().material.color;

        // Inicializar las posiciones de victoria
        InitializeVictoryPositions();
    }

    void InitializeVictoryPositions()
    {
        // Puedes ajustar las posiciones según tus necesidades
        victoryPositions = new Transform[2];
        victoryPositions[0] = new GameObject().transform;
        victoryPositions[0].position = new Vector3(1f, 1f, 1f); // Ejemplo de posición
        victoryPositions[1] = new GameObject().transform;
        victoryPositions[1].position = new Vector3(-1f, -1f, -1f); // Ejemplo de posición
    }

    void Update()
    {
        // Evitar nuevos giros si ya está rotando
        if (isRotating)
        {
            return;
        }

        // Gestionar la selección de la parte superior, inferior, izquierda, derecha, frontal o trasera
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
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            SelectFront();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SelectBack();
        }

        // Gestionar los inputs de flechas para los giros del cubo
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

        // Verificar la condición de victoria después de cada rotación
        CheckVictoryCondition();

        CheckVictory();
    }

    void CheckVictoryCondition()
    {
        // Verificar si ambos cubos de la victoria están en sus posiciones correctas
        bool isVictory = cubeOfVictory1.transform.position == victoryPosition1 &&
                         cubeOfVictory2.transform.position == victoryPosition2;

        // Si es victoria, mostrar el mensaje y puedes hacer otras acciones
        if (isVictory)
        {
            Debug.Log("¡Victoria!");
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
        // Obtener los cubos hijos del objeto vacío
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();

        foreach (Transform childCube in childCubes)
        {
            if (childCube != rubikCube.transform)
            {
                Renderer cubeRenderer = childCube.GetComponent<Renderer>();

                // Evitar cambiar el color de los cubos de victoria
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
    void SetVictoryCubeColor()
    {
        // Establecer el color de los cubos de la victoria
        Renderer victoryCubeRenderer1 = cubeOfVictory1.GetComponent<Renderer>();
        Renderer victoryCubeRenderer2 = cubeOfVictory2.GetComponent<Renderer>();

        victoryCubeRenderer1.material.color = victoryColor;
        victoryCubeRenderer2.material.color = victoryColor;
    }

    void RotateSelectedPart(Vector3 axis, float angle)
    {
        // Verificar la dirección de rotación permitida
        if ((isTopSelected || isBottomSelected) && axis != Vector3.up)
        {
            // Si la parte superior o inferior está seleccionada, solo permitir rotación vertical (eje Y)
            return;
        }
        else if ((isLeftSelected || isRightSelected) && axis != Vector3.right)
        {
            // Si la parte izquierda o derecha está seleccionada, solo permitir rotación horizontal (eje X)
            return;
        }
        else if ((isFrontSelected || isBackSelected) && axis != Vector3.forward)
        {
            // Si la parte frontal o trasera está seleccionada, solo permitir rotación en el eje Z
            return;
        }

        // Marcar que se está realizando una rotación
        isRotating = true;

        // Obtener los cubos de la parte seleccionada
        Transform[] selectedCubes = isTopSelected ? GetTopCubes() :
            isBottomSelected ? GetBottomCubes() :
            isLeftSelected ? GetLeftCubes() :
            isRightSelected ? GetRightCubes() :
            isFrontSelected ? GetFrontCubes() :
            isBackSelected ? GetBackCubes() :
            new Transform[0];

        // Calcular el pivote central
        Vector3 pivot = GetPivot(selectedCubes);

        // Iniciar la rotación suavizada para cada cubo de la parte seleccionada
        StartCoroutine(RotateOverTime(selectedCubes, pivot, axis, angle, rotationSpeed, () =>
        {
            // Marcar que la rotación ha terminado
            isRotating = false;
        }));
    }

    Transform[] GetTopCubes()
    {
        // Obtener los cubos hijos del objeto vacío
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        // Filtrar solo los cubos de la parte superior
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.y > rubikCube.transform.position.y);
    }

    Transform[] GetBottomCubes()
    {
        // Obtener los cubos hijos del objeto vacío
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        // Filtrar solo los cubos de la parte inferior
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.y < rubikCube.transform.position.y);
    }

    Transform[] GetLeftCubes()
    {
        // Obtener los cubos hijos del objeto vacío
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        // Filtrar solo los cubos de la parte izquierda
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.x < rubikCube.transform.position.x);
    }

    Transform[] GetRightCubes()
    {
        // Obtener los cubos hijos del objeto vacío
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        // Filtrar solo los cubos de la parte derecha
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.x > rubikCube.transform.position.x);
    }

    Transform[] GetFrontCubes()
    {
        // Obtener los cubos hijos del objeto vacío
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        // Filtrar solo los cubos de la parte frontal
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.z > rubikCube.transform.position.z);
    }

    Transform[] GetBackCubes()
    {
        // Obtener los cubos hijos del objeto vacío
        Transform[] childCubes = rubikCube.GetComponentsInChildren<Transform>();
        // Filtrar solo los cubos de la parte trasera
        return System.Array.FindAll(childCubes, childCube => childCube != rubikCube.transform && childCube.position.z < rubikCube.transform.position.z);
    }

    Vector3 GetPivot(Transform[] cubes)
    {
        // Calcular el centro de masa de los cubos
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

            // Aplicar corrección para evitar el desplazamiento acumulativo
            Quaternion deltaRotation = Quaternion.Euler(axis * angle * Time.deltaTime * speed);
            foreach (Transform targetTransform in targetTransforms)
            {
                Vector3 offset = targetTransform.position - pivot;
                targetTransform.position = pivot + deltaRotation * offset;
                targetTransform.rotation *= deltaRotation;
            }

            yield return null;
        }

        // Marcar que la rotación ha terminado
        onRotationComplete?.Invoke();
    }

    void CheckVictory()
    {
        // Verificar si los cubos de la victoria están cerca de alguna posición de victoria
        bool victoryAchieved = false;
        foreach (Transform victoryPosition in victoryPositions)
        {
            float distance1 = Vector3.Distance(cubeOfVictory1.transform.position, victoryPosition.position);
            float distance2 = Vector3.Distance(cubeOfVictory2.transform.position, victoryPosition.position);

            if (distance1 < 0.5f && distance2 < 0.5f)
            {
                victoryAchieved = true;
                break;
            }
        }

        // Mostrar mensaje de victoria si se logra la victoria
        if (victoryAchieved)
        {
            Debug.Log("¡Victoria!");
        }
    }
}
