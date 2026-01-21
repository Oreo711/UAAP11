using UnityEngine;



public class EnemyFactory
{
    private readonly Enemy _prefab;

    public EnemyFactory (Enemy prefab)
    {
        _prefab = prefab;
    }

    public Enemy Create (EnemyConfig config, Vector3 position)
    {
        Enemy enemy = Object.Instantiate(_prefab, position, Quaternion.identity);

        enemy.Initialize(config);
        return enemy;
    }
}
