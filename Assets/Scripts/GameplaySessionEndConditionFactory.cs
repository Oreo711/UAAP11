using System;
using Configs;
using Unity.VisualScripting;
using CoroutineRunner = DefaultNamespace.Miscellaneous.CoroutineRunner;


namespace DefaultNamespace
{
	public class GameplaySessionEndConditionFactory
	{
		private readonly EnemySpawner                       _enemySpawner;
		private readonly CoroutineRunner                    _coroutineRunner;
		private readonly GameplaySessionEndConditionsConfig _config;

		public GameplaySessionEndConditionFactory (EnemySpawner enemySpawner, GameplaySessionEndConditionsConfig config)
		{
			_enemySpawner = enemySpawner;
			_config       = config;
		}

		private KillCountCondition CreateKillCountCondition (int requiredKillCount)
		{
			return new KillCountCondition(requiredKillCount, _enemySpawner);
		}

		private SurvivalTimeCondition CreateSurvivalTimeCondition (float requiredSurvivalTime)
		{
			return new SurvivalTimeCondition(requiredSurvivalTime, _coroutineRunner);
		}

		private EnemyOverflowCondition CreateEnemyOverflowCondition (int maxEnemiesAllowed)
		{
			return new EnemyOverflowCondition(maxEnemiesAllowed);
		}

		private OutOfHealthCondition CreateOutOfHealthCondition ()
		{
			return new OutOfHealthCondition();
		}

		public IGameplaySessionEndCondition CreateWinConditionFor (WinConditions winCondition)
		{
			switch (winCondition)
			{
				case WinConditions.KillCount:
					return CreateKillCountCondition(_config.RequiredKillCount);
				case WinConditions.SurvivalTime:
					return CreateSurvivalTimeCondition(_config.RequiredSurvivalTime);
				default:
					throw new ArgumentOutOfRangeException("Invalid Win Condition Index!");
			}
		}

		public IGameplaySessionEndCondition CreateLossConditionFor (LossConditions lossCondition)
		{
			switch (lossCondition)
			{
				case LossConditions.enemyOverflow:
					return CreateEnemyOverflowCondition(_config.MaxEnemiesAllowed);
				case LossConditions.outOfHealth:
					return CreateOutOfHealthCondition();
				default:
					throw new ArgumentOutOfRangeException("Invalid Loss Condition Index!");
			}
		}
	}
}
