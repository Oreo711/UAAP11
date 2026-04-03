using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner
{
    private readonly EnemyConfig      _enemyConfig;
    private readonly Enemy            _prefab;
    private readonly EnemySpawnConfig _enemySpawnConfig;
    private readonly MonoBehaviour    _coroutineRunner;

    private readonly EnemyFactory _factory;

    public EnemySpawner (EnemyConfig enemyConfig, Enemy prefab, MonoBehaviour coroutineRunner, EnemySpawnConfig enemySpawnConfig)
    {
        _enemyConfig                = enemyConfig;
        _prefab                = prefab;
        _coroutineRunner       = coroutineRunner;
        _enemySpawnConfig      = enemySpawnConfig;
        _factory               = new EnemyFactory(_prefab);
    }

    public void Launch ()
    {
        _coroutineRunner.StartCoroutine(Spawn());
    }

    private IEnumerator Spawn ()
    {
        while (true)
        {
            yield return new WaitForSeconds(_enemySpawnConfig.Cooldown);

            _factory.Create(_enemyConfig, _enemySpawnConfig.SpawnPositions[Random.Range(0, _enemySpawnConfig.SpawnPositions.Count)]);
        }
    }
}
