using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    public static event Action Spawned;
    public static event Action Died;

    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private float         _contactDamage;

    public EnemyMovement Movement => _movement;

    public void Initialize (EnemyConfig config)
    {
        _movement.Initialize(config.MovementSettings);
    }

    private void Start ()
    {
        Spawned?.Invoke();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            health.TakeDamage(_contactDamage);
        }
    }

    public void OnShot ()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
