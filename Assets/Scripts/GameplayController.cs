using System;
using System.ComponentModel;
using Configs;
using DefaultNamespace;
using UnityEngine;

public class GameplayController
{
    private readonly PlayerSpawner                      _playerSpawner;
    private readonly EnemySpawner                       _enemySpawner;
    private readonly GameplaySessionEndConditionsConfig _sessionEndConditionConfig;
    private readonly GameplaySessionEndConditionFactory _sessionEndConditionFactory;
    private readonly IGameplaySessionEndCondition       _winCondition;
    private readonly IGameplaySessionEndCondition       _lossCondition;

    public GameplayController (
        PlayerSpawner playerSpawner,
        EnemySpawner enemySpawner,
        GameplaySessionEndConditionsConfig sessionEndConditionsConfig)
    {
        _playerSpawner             = playerSpawner;
        _enemySpawner              = enemySpawner;
        _sessionEndConditionConfig = sessionEndConditionsConfig;

        _sessionEndConditionFactory = new GameplaySessionEndConditionFactory(_enemySpawner, _sessionEndConditionConfig);

				_winCondition = _sessionEndConditionFactory
            .CreateWinConditionFor(_sessionEndConditionConfig.WinConditionIndex);
        _lossCondition = _sessionEndConditionFactory
            .CreateLossConditionFor(_sessionEndConditionConfig.LossConditionIndex);
    }

    public void Initialize ()
    {
        _winCondition.Initialize();
        _lossCondition.Initialize();

        _winCondition.Met  += HandleWinConditionMet;
        _lossCondition.Met += HandleLossConditionMet;

        Player player = _playerSpawner.Spawn();
        _enemySpawner.Launch();
    }

    private void HandleWinConditionMet ()
    {
        Debug.Log("Won!");
        _winCondition.Met  -= HandleWinConditionMet;
        _lossCondition.Met -= HandleLossConditionMet;
    }

    private void HandleLossConditionMet ()
    {
        Debug.Log("Lost.");
        _winCondition.Met  -= HandleWinConditionMet;
        _lossCondition.Met -= HandleLossConditionMet;
    }

    public void Dispose ()
    {
        _winCondition.Met  -= HandleWinConditionMet;
        _lossCondition.Met -= HandleLossConditionMet;

        _winCondition.Dispose();
        _lossCondition.Dispose();
    }
}
