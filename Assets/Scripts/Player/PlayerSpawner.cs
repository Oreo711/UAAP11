using Configs;


public class PlayerSpawner
{
	private readonly PlayerConfig      _playerConfig;
	private readonly Player            _prefab;
	private readonly PlayerSpawnConfig _playerSpawnConfig;

	private readonly PlayerFactory _playerFactory;

	public PlayerSpawner (PlayerConfig playerConfig, Player prefab, PlayerSpawnConfig playerSpawnConfig)
	{
		_playerConfig = playerConfig;
		_prefab = prefab;
		_playerSpawnConfig = playerSpawnConfig;

		_playerFactory = new PlayerFactory(_prefab);
	}

	public Player Spawn ()
	{
		return _playerFactory.Create(_playerConfig, _playerSpawnConfig.SpawnPosition);
	}
}
