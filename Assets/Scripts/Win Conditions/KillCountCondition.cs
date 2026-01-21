using System;
using UnityEngine;


public class KillCountCondition : IGameplaySessionEndCondition
{
	public event Action Met;

	private int _requiredKillCount;

	public KillCountCondition (int requiredKillCount)
	{
		_requiredKillCount = requiredKillCount;
	}

	public void Initialize ()
	{
		Enemy.Died += HandleEnemyDied;
	}

	private void HandleEnemyDied ()
	{
		_requiredKillCount--;

		if (_requiredKillCount <= 0)
		{
			Met?.Invoke();
		}
	}

	public void Dispose ()
	{
		Enemy.Died -= HandleEnemyDied;
	}
}
