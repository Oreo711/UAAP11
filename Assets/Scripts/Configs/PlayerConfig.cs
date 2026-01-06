using UnityEngine;


[CreateAssetMenu(fileName = "PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
	[field: SerializeField] public float Walkspeed {get; private set;}

	[field: SerializeField] public float RotationSpeed {get; private set;}

	[field: SerializeField] public Player Prefab {get; private set;}

	[field: SerializeField] public Transform SpawnPoint {get; private set;}
}
