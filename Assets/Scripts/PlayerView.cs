using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update ()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.LookRotation(_player.Movement.Direction),
            _player.Movement.RotationSpeed * Time.deltaTime);
    }
}
