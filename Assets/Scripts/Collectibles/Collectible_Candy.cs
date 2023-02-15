using UnityEngine;

public class Collectible_Candy : Collectible_Base
{
    public int value;
    protected override void Collect()
    {
        base.Collect();
        Collectible_Manager.instance.AddCandies(value);
    }
}
