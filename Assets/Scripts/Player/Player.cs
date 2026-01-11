using System;
using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour, IDirectable, IHealth
{
	public static event Action Died;

	[SerializeField] private PlayerMovement _movement;
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _invincibilityDuration;

	private bool _canTakeDamage = true;

	public PlayerMovement Movement => _movement;

	public void Initialize (PlayerConfig config)
	{
		_movement.Initialize(config.MovementSettings);
		CurrentHealth = MaxHealth;
	}

	public Vector3 Direction     => _movement.Direction;

	public float MaxHealth     => _maxHealth;
	public float CurrentHealth {get; set;}

	public void TakeDamage (float damage)
	{
		if (damage < 0)
			return;

		if (_canTakeDamage == false)
			return;

		CurrentHealth -= damage;

		CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

		Debug.Log("Hurt");

		StartCoroutine(Invincibility());

		if (CurrentHealth <= 0)
		{
			Died?.Invoke();
		}
	}

	private IEnumerator Invincibility ()
	{
		_canTakeDamage = false;

		yield return new WaitForSeconds(_invincibilityDuration);

		_canTakeDamage = true;
	}
}
