using UnityEngine;


public class Player : MonoBehaviour
{
	[SerializeField] private PlayerMovement _movement;

	public void Initialize (PlayerConfig config)
	{
		_movement.Initialize(config.MovementSettings);
	}

	public Vector3 Position => transform.position;
}
