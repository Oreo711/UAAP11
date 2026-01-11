using UnityEngine;

public class ProjectileFactory
{
    private readonly Projectile _prefab;

    public ProjectileFactory (Projectile prefab)
    {
        _prefab = prefab;
    }

    public Projectile Create (Vector3 position, Vector3 direction, float speed, float lifespan)
    {
        Projectile instance = Object.Instantiate(_prefab);

        instance.transform.position = position;
        instance.Launch(direction, speed, lifespan);
        return instance;
    }
}
