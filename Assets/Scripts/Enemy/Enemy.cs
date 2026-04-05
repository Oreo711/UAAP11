using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    public event Action<Enemy> Died;

    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private float         _contactDamage;

    public EnemyMovement Movement => _movement;

    public void Initialize (EnemyConfig config)
    {
        _movement.Initialize(config.MovementSettings);
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
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
