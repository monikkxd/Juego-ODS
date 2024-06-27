using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoFinished : MonoBehaviour
{
    public GameManagerAlex gameManagerAlex;

    private void Start()
    {
        gameManagerAlex = FindAnyObjectByType<GameManagerAlex>();
    }
    public void IniciarJuego()
    {
        gameManagerAlex.TutorialAcabado();
    }
}
