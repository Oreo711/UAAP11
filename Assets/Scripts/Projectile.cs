
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _direction;
    private float   _speed;
    private float   _lifespan;

    public void Initialize (Vector3 direction, float speed, float lifespan)
    {
        _direction = direction;
        _speed     = speed;
        _lifespan  = lifespan;
    }

    private void Start ()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        StartCoroutine(Move());
    }

    private IEnumerator Move ()
    {
        while (_lifespan > 0)
        {
            _lifespan -= Time.fixedDeltaTime;
            transform.Translate(_direction * (_speed * Time.deltaTime));

            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }
}
