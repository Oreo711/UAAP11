using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	private float               _walkspeed;
	private float               _rotationSpeed;
	private CharacterController _controller;

	private void Awake ()
	{
		_controller = GetComponent<CharacterController>();
	}

	public void Initialize (MovementSettings settings)
	{
		_walkspeed     = settings.WalkSpeed;
		_rotationSpeed = settings.RotationSpeed;
	}

	private void Update ()
	{
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		_controller.Move(input * (_walkspeed * Time.deltaTime));
	}
}