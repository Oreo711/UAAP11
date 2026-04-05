using System;
using UnityEngine;


public class KillCountCondition : IGameplaySessionEndCondition
{
	public event Action Met;

	private          int          _requiredKillCount;
	private readonly EnemySpawner _enemySpawner;

	public KillCountCondition (int requiredKillCount, EnemySpawner enemySpawner)
	{
		_requiredKillCount = requiredKillCount;
		_enemySpawner = enemySpawner;
	}

	public void Initialize ()
	{
		_enemySpawner.EnemySpawned += HandleEnemyDied;
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
		_enemySpawner.EnemySpawned -= HandleEnemyDied;
	}
}
