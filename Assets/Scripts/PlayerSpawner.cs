using System;
using UnityEngine;

public class PlayerSpawner
{
	private readonly PlayerConfig _config;

	public PlayerSpawner (PlayerConfig config)
	{
		_config = config;
	}

	private readonly PlayerFactory _playerFactory = new PlayerFactory();

	public void Spawn ()
	{
		_playerFactory.CreatePlayer(_config);
	}
}
