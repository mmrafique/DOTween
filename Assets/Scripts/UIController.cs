using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button playButton;
    public Button restartButton;
    public DotweenActivityController controller;

    void Start()
    {
        playButton.onClick.AddListener(() => controller.PlayAll());
        restartButton.onClick.AddListener(() => controller.RestartAll());
    }
}