using System;
using UnityEngine;


public class EnemyOverflowCondition : IGameplayBreakCondition
{
	public event Action Met;

	private readonly int _requiredEnemyCount;
	private int _currentEnemyCount;

	public EnemyOverflowCondition (int requiredEnemyCount)
	{
		_requiredEnemyCount =  requiredEnemyCount;
		Enemy.Spawned += HandleEnemySpawned;
		Enemy.Died += HandleEnemyDied;
	}

	private void HandleEnemySpawned ()
	{
		_currentEnemyCount++;

		if (_currentEnemyCount >= _requiredEnemyCount)
		{
			Met?.Invoke();
		}
	}

	private void HandleEnemyDied ()
	{
		_currentEnemyCount--;
	}
}
