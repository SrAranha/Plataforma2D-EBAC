using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimHelper : MonoBehaviour
{
    private PlayerController player;
    public AudioSource footstepAudioSource;
    public List<AudioClip> footstepAudioClipList;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }
    public void KillPlayer()
    {
        Destroy(player.gameObject);
    }
    public void FootstepSound()
    {
        footstepAudioSource.clip = footstepAudioClipList[Random.Range(0, footstepAudioClipList.Count -1)];
        footstepAudioSource.Play();
    }
}
