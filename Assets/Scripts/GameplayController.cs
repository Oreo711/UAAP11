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

    private IGameplaySessionEndCondition _winCondition;
    private IGameplaySessionEndCondition _lossCondition;

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
    }

    private void Start ()
    {
        Initialize();
    }

    private void Initialize ()
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

    private void OnDestroy ()
    {
        _winCondition.Met  -= HandleWinConditionMet;
        _lossCondition.Met -= HandleLossConditionMet;

        _winCondition.Dispose();
        _lossCondition.Dispose();
    }
}
