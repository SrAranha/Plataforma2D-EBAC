using UnityEngine;

[CreateAssetMenu]
public class SO_PlayerSetup : ScriptableObject
{
    [Header("Player Movement")]
    public float speed;
    public float speedRun;
    public float manualFriction;
    public float jumpForce;
    [Min(1)]
    public int jumpsAmount;

    [Header("Animation")]
    public Animator animator;
    public string runParam;
    public string jumpParam;
    public string groundParam;
    public string jumpingParam;
}
