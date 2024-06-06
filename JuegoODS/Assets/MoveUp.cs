using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveUp : MonoBehaviour
{
    public float speed = 1.0f;

    private float elapsedTime = 0f;


    void Update()
    {
        elapsedTime += Time.deltaTime;

        float moveAmount = speed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);

        if (elapsedTime >= 44f)
        {
            Invoke("CargarMenú", 3f);
        }
    }

    void CargarMenú()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
