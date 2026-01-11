using UnityEngine;



public class EnemyFactory
{
    private Enemy _prefab;

    public EnemyFactory (Enemy prefab)
    {
        _prefab = prefab;
    }

    public Enemy Create (EnemyConfig config, Vector3 position)
    {
        Enemy enemy = Object.Instantiate(_prefab);
        enemy.transform.position = position;

        enemy.Initialize(config);
        return enemy;
    }
}
