using UnityEngine;

public class EnemyView : MonoBehaviour
{
	[SerializeField] private Enemy _enemy;

	private void Update ()
	{
		Quaternion.RotateTowards(transform.rotation,
			Quaternion.LookRotation(_enemy.Movement.Direction),
			_enemy.Movement.RotationSpeed * Time.deltaTime);
	}
}
