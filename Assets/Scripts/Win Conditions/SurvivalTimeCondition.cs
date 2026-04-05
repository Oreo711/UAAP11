using System;
using System.Collections;
using DefaultNamespace.Miscellaneous;
using UnityEngine;

public class SurvivalTimeCondition : IGameplaySessionEndCondition
{
    public event Action Met;

    private readonly float _time;
    private readonly CoroutineRunner _coroutineRunner;

    public SurvivalTimeCondition (float time, CoroutineRunner coroutineRunner)
    {
        _time = time;
        _coroutineRunner = coroutineRunner;
    }

    public void Initialize ()
    {
        _coroutineRunner.StartCoroutine(Run());
    }

    private IEnumerator Run ()
    {
        yield return new WaitForSeconds(_time);

        Met?.Invoke();
    }

    public void Dispose ()
    {

    }
}
