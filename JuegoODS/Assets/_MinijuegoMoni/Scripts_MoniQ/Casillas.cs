using UnityEngine;

public class Casillas : MonoBehaviour
{
    public float tamanoCasilla = 1f;

    void OnDrawGizmos()
    {
        DividirObjetoEnCasillas();
    }

    void DividirObjetoEnCasillas()
    {
        Renderer renderer = GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;

        float mitadTamanoCasilla = tamanoCasilla / 2.0f;

        Gizmos.color = Color.blue;

        for (float x = bounds.min.x + mitadTamanoCasilla; x < bounds.max.x; x += tamanoCasilla)
        {
            for (float z = bounds.min.z + mitadTamanoCasilla; z < bounds.max.z; z += tamanoCasilla)
            {
                Vector3 centroCasilla = new Vector3(x, transform.position.y, z);
                Gizmos.DrawWireCube(centroCasilla, new Vector3(tamanoCasilla, 0.1f, tamanoCasilla));

                Debug.Log("Casillas Dibujadas");
            }
        }
    }
}
