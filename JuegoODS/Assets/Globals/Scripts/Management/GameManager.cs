using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static new GameManager Instance;

    private int _targetFrameRate = 30;

    [Header("Loading Values")]

    public static bool IsLoading = false;
    public static event Action<string> OnNextScene;


    [Header("Pause Values")]

    public static bool IsPause = false;
    public static event Action OnPause;
    [SerializeField] private static GameObject _pausePrefab;



    protected override void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = _targetFrameRate;
    }

    private void Start()
    {
        // Discutir cual de las opciones es mejor
        SceneManager.LoadScene("Introduccion");
        //NextScene(0);
    }

    private void Update()
    {
        // Para testear el Pause cuando tengamos el sistema de inputs bueno cambiar
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    #region SceneManager

    public static void LoadScene(GameScene scene)
    {
        if (IsLoading)
            return;

        string sceneName = SceneParse(scene);

        IsLoading = true;
        OnNextScene?.Invoke(sceneName);

        SceneManager.LoadSceneAsync(sceneName);
    }

    public static string SceneParse(GameScene scene)
    {
        return scene switch
        {
            GameScene.Intro => "Introduccion",
            GameScene.MenuPrincipal => "MenuPrincipal",
            GameScene.Level1 => "Level1",
            GameScene.Level2 => "Level2",
            GameScene.Level3 => "Level3",
            GameScene.Level4 => "Level4",
            GameScene.PantallaFinal => "PantallaFinal",
            _ => "MenuPrincipal",
        };
    }

    #endregion

    #region Pause

    public static void PauseGame()
    {
        IsPause = !IsPause;
        OnPause();
    }

    #endregion


}

public enum GameScene
{
    Intro,
    MenuPrincipal,
    Level1,
    Level2,
    Level3,
    Level4,
    PantallaFinal
}

