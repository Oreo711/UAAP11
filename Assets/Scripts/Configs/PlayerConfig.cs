using System;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
	[SerializeField] private MovementSettings _movementSettings;

	public MovementSettings MovementSettings => _movementSettings;

}

[Serializable]
public class MovementSettings
{
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _rotationSpeed;

	public float WalkSpeed     => _walkSpeed;
	public float RotationSpeed => _rotationSpeed;
}
