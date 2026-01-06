using UnityEngine;

public class PlayerFactory
{
    public Player CreatePlayer (PlayerConfig config)
    {
        Player player = Object.Instantiate(config.Prefab);
        player.transform.position = Vector3.zero;

        player.Initialize(config);
        return player;
    }
}
