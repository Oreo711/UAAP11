using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.limeGreen;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
