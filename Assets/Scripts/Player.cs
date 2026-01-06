using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;

    private float               _walkspeed;
    private float               _rotationSpeed;
    private CharacterController _controller;

    private void Awake ()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Initialize (PlayerConfig config)
    {
        _walkspeed     = config.Walkspeed;
        _rotationSpeed = config.RotationSpeed;
    }

    public Vector3 Position => transform.position;

    public Transform CameraTarget => _cameraTarget;

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _controller.Move(input * (_walkspeed * Time.deltaTime));
    }
}
