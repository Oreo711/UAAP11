using System;
using Configs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class EntryPoint : MonoBehaviour
{
	[SerializeField] private GameObject         _environment;
	[SerializeField] private GameplayController _gameplayController;
	[SerializeField] private Player             _playerPrefab;
	[SerializeField] private Enemy              _enemyPrefab;


	private void Awake ()
	{
		Instantiate(_environment, Vector3.zero, Quaternion.Euler(0, 135, 0));
		GameplayController gameplayController = Instantiate(_gameplayController);

		gameplayController.Initialize(new PlayerSpawner(
			Resources.Load<PlayerConfig>("Configs/PlayerConfig"),
			_playerPrefab,
			Resources.Load<PlayerSpawnConfig>("Configs/PlayerSpawnConfig")),
			new EnemySpawner(Resources.Load<EnemyConfig>("Configs/EnemyConfig"),
				_enemyPrefab,
				this,
				Resources.Load<EnemySpawnConfig>("Configs/EnemySpawnConfig")));
	}
}
