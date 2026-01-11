using UnityEngine;


public class PlayerSpawner : MonoBehaviour
{
	[SerializeField] private PlayerConfig _config;
	[SerializeField] private Player       _prefab;
	[SerializeField] private Transform    _spawnPoint;

	private PlayerFactory _playerFactory;

	private void Awake ()
	{
		_playerFactory = new PlayerFactory(_prefab);
	}

	public Player Spawn ()
	{
		return _playerFactory.Create(_config, _spawnPoint.position);
	}
}
