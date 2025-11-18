using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScenarioBController : MonoBehaviour
{
    public Transform cube1;
    public Transform cube2;

    Sequence sequence;
    Vector3 start1, start2;

    void Awake()
    {
        start1 = cube1.position;
        start2 = cube2.position;
    }

    public void Play()
    {
        if (sequence != null) sequence.Kill();

        sequence = DOTween.Sequence();

        // 1 - Mover cube1 hacia delante
        sequence.Append(
            cube1.DOMove(cube1.position + Vector3.forward * 1.2f, 0.6f)
        );

        // 2 - Rotación de cube1
        sequence.Append(
            cube1.DORotate(new Vector3(0, 180, 0), 0.5f, RotateMode.LocalAxisAdd)
        );

        // 3 - Salto simultáneo de cube2
        sequence.Join(
            cube2.DOJump(cube2.position + Vector3.up * 1.5f, 1f, 1, 0.8f)
        );

        // 4 - Mover cube2 a la derecha
        sequence.Append(
            cube2.DOMove(cube2.position + Vector3.right * 1f, 0.6f)
        );

        // 5 - Escalado simultáneo de cube1
        sequence.Join(
            cube1.DOScale(cube1.localScale * 1.3f, 0.4f).SetLoops(2, LoopType.Yoyo)
        );

        // 6 - Vuelta al inicio de ambos
        sequence.AppendInterval(0.2f);
        sequence.Append(cube1.DOMove(start1, 0.6f));
        sequence.Join(cube2.DOMove(start2, 0.6f));

        sequence.OnComplete(() => Debug.Log("Scenario B Complete"));
    }

    public void Restart()
    {
        if (sequence != null) sequence.Kill();

        cube1.position = start1;
        cube2.position = start2;

        cube1.localScale = Vector3.one;
        cube2.localScale = Vector3.one;

        cube1.rotation = Quaternion.identity;
        cube2.rotation = Quaternion.identity;
    }

    public void Pause()
    {
        if (sequence != null) sequence.Pause();
    }
}