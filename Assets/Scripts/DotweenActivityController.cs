using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotweenActivityController : MonoBehaviour
{
    public ScenarioAController scenarioA;
    public ScenarioBController scenarioB;

    void Start()
    {
        PauseAll();
    }

    public void PlayAll()
    {
        scenarioA.Play();
        scenarioB.Play();
    }

    public void RestartAll()
    {
        scenarioA.Restart();
        scenarioB.Restart();
    }

    public void PauseAll()
    {
        scenarioA.Pause();
        scenarioB.Pause();
    }
}
