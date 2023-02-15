using UnityEngine;

public class PlayerAnimHelper : MonoBehaviour
{
    private PlayerController player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }
    public void KillPlayer()
    {
        Destroy(player.gameObject);
    }
}
