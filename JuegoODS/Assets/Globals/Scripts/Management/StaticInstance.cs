using UnityEngine;

/// <summary>
/// Instancia est�tica.
/// Una nueva instancia sobreescribe a la anterior, reiniciando su estado.
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// Instancia singleton.
/// La nueva instancia es eliminada si existe una anterior, asegur�ndose de que s�lo existe una instancia.
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"{typeof(T).Name} already exists in scene. Destroying...");
            Destroy(gameObject);
        }

        base.Awake();
    }
}

/// <summary>
/// Instancia singleton persistente.
/// La instancia no se destruir� al cambiar de escenas, generando as� una instancia persistente a nivel de juego.
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }
}