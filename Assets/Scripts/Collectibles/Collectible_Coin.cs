using UnityEngine;

public class Collectible_Coin : Collectible_Base
{
    [Header("Coin")]
    public int value;
    protected override void Collect()
    {
        base.Collect();
        Collectible_Manager.instance.AddCoins(value);
    }
}
