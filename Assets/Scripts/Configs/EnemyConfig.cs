using System;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
	[SerializeField] private EnemyMovementSettings _movementSettings;

	public EnemyMovementSettings MovementSettings => _movementSettings;

}

[Serializable]
public class EnemyMovementSettings
{
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _redirectionCooldown;

	public float WalkSpeed           => _walkSpeed;
	public float RotationSpeed       => _rotationSpeed;
	public float RedirectionCooldown => _redirectionCooldown;
}
