using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScenarioAController : MonoBehaviour
{
    public Transform cube;
    public Transform targetPoint;

    public float jumpPower = 2f;
    public int numJumps = 1;
    public float duration = 1.5f;

    Vector3 startPosition;
    Tween currentTween;

    void Awake()
    {
        startPosition = cube.position;
    }

    public void Play()
    {
        if (currentTween != null) currentTween.Kill();

        currentTween = cube
            .DOJump(targetPoint.position, jumpPower, numJumps, duration)
            .SetEase(Ease.OutQuad);
    }

    public void Restart()
    {
        if (currentTween != null) currentTween.Kill();
        cube.position = startPosition;
    }

    public void Pause()
    {
        if (currentTween != null) currentTween.Pause();
    }
}