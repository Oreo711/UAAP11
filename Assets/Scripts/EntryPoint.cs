using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
	[SerializeField] private PlayerConfig _playerConfig;

	private PlayerSpawner _spawner;

	private void Awake ()
	{
		_spawner = new PlayerSpawner(_playerConfig);
		_spawner.Spawn();
	}
}
