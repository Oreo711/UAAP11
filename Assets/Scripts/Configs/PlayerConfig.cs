using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
	[SerializeField] private PlayerMovementSettings _movementSettings;

	public PlayerMovementSettings MovementSettings => _movementSettings;

}

[Serializable]
public class PlayerMovementSettings
{
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _rotationSpeed;

	public float WalkSpeed     => _walkSpeed;
	public float RotationSpeed => _rotationSpeed;
}
