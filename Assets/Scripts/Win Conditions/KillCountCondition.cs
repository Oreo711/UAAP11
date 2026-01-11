using System;
using UnityEngine;

public class KillCountCondition : IGameplayBreakCondition
{
	public event Action Met;

	private int _requiredKillCount;

	public KillCountCondition (int requiredKillCount)
	{
		_requiredKillCount = requiredKillCount;
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
}
