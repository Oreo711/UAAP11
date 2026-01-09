using UnityEngine;


[RequireComponent(typeof(IDirectable))]
public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private float      _projectileSpeed;
    [SerializeField] private float      _projectileLifespan;

    private ProjectileFactory _factory;
    private IDirectable _directable;

    private void Awake ()
    {
        _factory = new ProjectileFactory(_prefab);
        _directable = GetComponent<IDirectable>();
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _factory.Create(transform.position, _directable.Direction, _projectileSpeed, _projectileLifespan);
        }
    }
}
