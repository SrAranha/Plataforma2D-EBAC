using UnityEngine;

public class PlayerAnimHelper : MonoBehaviour
{
    public PlayerController player;
    public void KillPlayer()
    {
        Destroy(player.gameObject);
    }
}
