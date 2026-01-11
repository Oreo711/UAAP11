using System;
using System.Collections;
using UnityEngine;

public class SurvivalTimeCondition : IGameplayBreakCondition
{
    public event Action Met;

    private readonly float _time;
    private readonly MonoBehaviour _coroutineRunner;

    public SurvivalTimeCondition (float time, MonoBehaviour coroutineRunner)
    {
        _time = time;
        _coroutineRunner = coroutineRunner;
    }

    public void Start ()
    {
        _coroutineRunner.StartCoroutine(Run());
    }

    private IEnumerator Run ()
    {
        yield return new WaitForSeconds(_time);

        Met?.Invoke();
    }
}
