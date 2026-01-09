using UnityEngine;


public class Player : MonoBehaviour, IDirectable
{
	[SerializeField] private PlayerMovement _movement;

	public PlayerMovement Movement => _movement;

	public void Initialize (PlayerConfig config)
	{
		_movement.Initialize(config.MovementSettings);
	}

	public Vector3 Position  => transform.position;
	public Vector3 Direction => _movement.Direction;
}
