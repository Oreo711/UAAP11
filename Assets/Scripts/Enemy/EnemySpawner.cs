using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyConfig     _config;
    [SerializeField] private Enemy           _prefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float           _cooldown;

    private EnemyFactory _factory;

    private void Awake ()
    {
        _factory = new EnemyFactory(_prefab);
    }

    public void Launch ()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn ()
    {
        while (true)
        {
            yield return new WaitForSeconds(_cooldown);

            _factory.Create(_config, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
        }
    }
}
