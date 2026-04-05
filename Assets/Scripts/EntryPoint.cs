using System;
using Configs;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class EntryPoint : MonoBehaviour
{
	[SerializeField] private GameObject         _environment;
	[SerializeField] private GameplayController _gameplayController;
	[SerializeField] private Player             _playerPrefab;
	[SerializeField] private Enemy              _enemyPrefab;

	private GameplayController _controller;

	private void Awake ()
	{
		Instantiate(_environment, Vector3.zero, Quaternion.Euler(0, 135, 0));

		GameplayController gameplayController = new GameplayController(new PlayerSpawner(
				Resources.Load<PlayerConfig>("Configs/PlayerConfig"),
				_playerPrefab,
				Resources.Load<PlayerSpawnConfig>("Configs/PlayerSpawnConfig")),
			new EnemySpawner(Resources.Load<EnemyConfig>("Configs/EnemyConfig"),
				_enemyPrefab,
				this,
				Resources.Load<EnemySpawnConfig>("Configs/EnemySpawnConfig")),
			Resources.Load<GameplaySessionEndConditionsConfig>("Configs/GameplaySessionEndConditionsConfig"));

		_controller = gameplayController;
	}

	private void Start ()
	{
		_controller.Initialize();
	}

	private void OnDestroy ()
	{
		_controller.Dispose();
	}
}
