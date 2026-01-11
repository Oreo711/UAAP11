using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private PlayerSpawner  _playerSpawner;
    [SerializeField] private EnemySpawner   _enemySpawner;
    [SerializeField] private WinConditions  _winConditionIndex;
    [SerializeField] private LossConditions _lossConditionIndex;
    [SerializeField] private float          _requiredSurvivalTime;
    [SerializeField] private int            _requiredKillCount;
    [SerializeField] private int            _maxEnemiesAllowed;

    private IGameplayBreakCondition _winCondition;
    private IGameplayBreakCondition _lossCondition;

    private void Awake ()
    {
        switch (_winConditionIndex)
        {
            case WinConditions.SurvivalTime:
                _winCondition = new SurvivalTimeCondition(_requiredSurvivalTime, this);
                break;
            case WinConditions.KillCount:
                _winCondition = new KillCountCondition(_requiredKillCount);
                break;
            default:
                throw new InvalidEnumArgumentException("Invalid value for Win Condition Index");
        }

        switch (_lossConditionIndex)
        {
            case LossConditions.enemyOverflow:
                _lossCondition = new EnemyOverflowCondition(_maxEnemiesAllowed);
                break;
            case LossConditions.outOfHealth:
                _lossCondition = new OutOfHealthCondition();
                break;
            default:
                throw new InvalidEnumArgumentException("Invalid value for Loss Condition Index");
        }

        Initialize();
    }

    private void Start ()
    {
        _winCondition.Met  += HandleWinConditionMet;
        _lossCondition.Met += HandleLossConditionMet;
    }

    private void Initialize ()
    {
        Player player = _playerSpawner.Spawn();
        _enemySpawner.Launch();
    }

    private void HandleWinConditionMet ()
    {
        Debug.Log("Won!");
    }

    private void HandleLossConditionMet ()
    {
        Debug.Log("Lost.");
    }
}
