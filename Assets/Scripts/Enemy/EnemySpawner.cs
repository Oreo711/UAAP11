using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner
{
    public event Action EnemySpawned;
    public event Action EnemyDied;

    private readonly EnemyConfig      _enemyConfig;
    private readonly Enemy            _prefab;
    private readonly EnemySpawnConfig _enemySpawnConfig;
    private readonly MonoBehaviour    _coroutineRunner;
    private readonly EnemyFactory _factory;

    public EnemySpawner (EnemyConfig enemyConfig, Enemy prefab, MonoBehaviour coroutineRunner, EnemySpawnConfig enemySpawnConfig)
    {
        _enemyConfig           = enemyConfig;
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

            Enemy enemy = _factory.Create(
                _enemyConfig,
                _enemySpawnConfig.SpawnPositions[Random.Range(0, _enemySpawnConfig.SpawnPositions.Count)]);
            EnemySpawned?.Invoke();

            enemy.Died += OnEnemyDied;
        }
    }

    private void OnEnemyDied (Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        EnemyDied?.Invoke();
    }


}
