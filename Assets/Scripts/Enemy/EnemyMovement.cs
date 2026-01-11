using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyMovement : MonoBehaviour
{
    private float               _walkSpeed;
    private float               _rotationSpeed;
    private float               _redirectionCooldown;
    private Vector3             _direction;
    private CharacterController _controller;

    public float RotationSpeed => _rotationSpeed;

    public void Initialize(EnemyMovementSettings settings)
    {
        _walkSpeed           = settings.WalkSpeed;
        _rotationSpeed       = settings.RotationSpeed;
        _redirectionCooldown = settings.RedirectionCooldown;
    }

    private void Start ()
    {
        _controller = GetComponent<CharacterController>();

        StartCoroutine(Redirect());
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.TryGetComponent(out Barrier barrier))
        {
            _direction = -_direction;
        }
    }

    private void FixedUpdate ()
    {
        _controller.Move(_direction * (_walkSpeed * Time.deltaTime));
    }

    private IEnumerator Redirect ()
    {
        while (true)
        {
            SwitchDirection();

            yield return new WaitForSeconds(_redirectionCooldown);
        }
    }

    private void SwitchDirection ()
    {
        _direction = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)).normalized;
    }
}
