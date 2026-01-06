using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.pink;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
