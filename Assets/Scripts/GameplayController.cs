using System;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;

    private void Start ()
    {
        Initialize();
    }

    private void Initialize ()
    {
        Player player = _playerSpawner.Spawn();
    }
}
