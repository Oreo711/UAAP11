using UnityEngine;


namespace Configs
{
	[CreateAssetMenu(fileName = "GameplaySessionEndConditionsConfig")]
	public class GameplaySessionEndConditionsConfig : ScriptableObject
	{
		[SerializeField] private WinConditions  _winConditionIndex;
		[SerializeField] private LossConditions _lossConditionIndex;
		[SerializeField] private float          _requiredSurvivalTime;
		[SerializeField] private int            _requiredKillCount;
		[SerializeField] private int            _maxEnemiesAllowed;

		public WinConditions WinConditionIndex => _winConditionIndex;
		public LossConditions LossConditionIndex => _lossConditionIndex;
		public float RequiredSurvivalTime => _requiredSurvivalTime;
		public int RequiredKillCount => _requiredKillCount;
		public int MaxEnemiesAllowed => _maxEnemiesAllowed;
	}
}
