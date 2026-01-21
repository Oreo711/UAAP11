using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	private float                   _walkSpeed;
	private float                   _rotationSpeed;
	private CharacterController     _controller;
	private Vector3 _input;

	public Vector3 Direction     {get; private set;} = Vector3.forward;
	public float   RotationSpeed => _rotationSpeed;

	private void Awake ()
	{
		_controller = GetComponent<CharacterController>();
		// Direction   = new Vector3(0, 0, 1);
	}

	public void Initialize (PlayerMovementSettings settings)
	{
		_walkSpeed     = settings.WalkSpeed;
		_rotationSpeed = settings.RotationSpeed;
	}

	private void Update ()
	{
		_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
	}

	private void FixedUpdate ()
	{
		if (_input == Vector3.zero)
			return;

		Direction = _input;
		_controller.Move(_input * (_walkSpeed * Time.deltaTime));
	}
}
