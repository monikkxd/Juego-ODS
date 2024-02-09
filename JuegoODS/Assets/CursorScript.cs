using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float mouseSensitivity = 1.0f;

    private Vector2 cursorHostpot;

    private void Start()
    {
        cursorHostpot = new Vector2(cursorTexture.width, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHostpot, CursorMode.Auto);
    }

    private void Update()
    {
        // Modificar la sensibilidad del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Realizar alguna acción con los valores ajustados, por ejemplo, mover el cursor
        // Puedes ajustar esto según tus necesidades específicas
        transform.Translate(new Vector3(mouseX, mouseY, 0) * Time.deltaTime);
    }
}
