using UnityEngine;


namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerSpawnConfig")]
    public class PlayerSpawnConfig : ScriptableObject
    {
        [SerializeField] private Vector3 _spawnPosition;

        public Vector3 SpawnPosition => _spawnPosition;
    }
}
