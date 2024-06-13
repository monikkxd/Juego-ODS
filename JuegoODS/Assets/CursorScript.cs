using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float mouseSensitivity = 1.0f;

    private Vector2 cursorHostpot;
    private void Start()
    {
        cursorHostpot = new Vector2(cursorTexture.width, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHostpot, CursorMode.Auto);

        Cursor.visible = true;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Translate(new Vector3(mouseX, mouseY, 0) * Time.deltaTime);
    }

}
