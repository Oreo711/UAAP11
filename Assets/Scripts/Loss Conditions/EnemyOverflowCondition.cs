using System;


public class EnemyOverflowCondition : IGameplaySessionEndCondition
{
	public event Action Met;

	private readonly int          _requiredEnemyCount;
	private          EnemySpawner _enemySpawner;
	private          int          _currentEnemyCount;

	public EnemyOverflowCondition (int requiredEnemyCount)
	{
		_requiredEnemyCount =  requiredEnemyCount;
	}

	public void Initialize ()
	{
		_enemySpawner.EnemySpawned += HandleEnemyEnemySpawned;
		 _enemySpawner.EnemyDied += HandleEnemyDied;
	}

	private void HandleEnemyEnemySpawned ()
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

	public void Dispose ()
	{
		_enemySpawner.EnemySpawned -= HandleEnemyEnemySpawned;
		_enemySpawner.EnemyDied    -= HandleEnemyDied;
	}
}
