using UnityEngine;

public class PlayerFactory
{
    private readonly Player _prefab;

    public PlayerFactory (Player prefab)
    {
        _prefab = prefab;
    }

    public Player Create (PlayerConfig config, Vector3 position)
    {
        Player player = Object.Instantiate(_prefab, position, Quaternion.identity);

        player.Initialize(config);
        return player;
    }
}
