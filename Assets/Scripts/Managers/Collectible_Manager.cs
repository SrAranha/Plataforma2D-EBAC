using TMPro;
using UnityEngine;

public class Collectible_Manager : Singleton<Collectible_Manager>
{
    public TMP_Text text;
    public int coins;

    private void Start()
    {
        ResetCoins();
    }
    private void Update()
    {
        text.text = "x " + coins.ToString();
    }
    private void ResetCoins()
    {
        coins = 0;
    }
    public void AddCoins(int value)
    {
        coins += value;
    }
}