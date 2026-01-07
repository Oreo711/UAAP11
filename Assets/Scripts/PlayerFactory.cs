using UnityEngine;

public class PlayerFactory
{
    private readonly Player _prefab;

    public PlayerFactory (Player prefab)
    {
        _prefab = prefab;
    }

    public Player Create (PlayerConfig config)
    {
        Player player = Object.Instantiate(_prefab);
        player.transform.position = Vector3.zero;

        player.Initialize(config);
        return player;
    }
}
