using System.Collections.Generic;
using UnityEngine;


namespace Configs
{
	[CreateAssetMenu(fileName = "EnemySpawnConfig")]
	public class EnemySpawnConfig : ScriptableObject
	{
		[SerializeField] private List<Vector3> _spawnPositions;
		[SerializeField] private float _cooldown;

		public List<Vector3> SpawnPositions => _spawnPositions;
		public float Cooldown => _cooldown;
	}
}
