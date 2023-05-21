using TMPro;

public class Collectible_Manager : Singleton<Collectible_Manager>
{
    public SO_Collectibles collectibles;
    public TMP_Text textCoins;
    public TMP_Text textCandies;

    private void Start()
    {
        ResetCollectibles();
    }
    private void Update()
    {
        textCoins.text = "x " + collectibles.coins.ToString();
        textCandies.text = "x " + collectibles.candies.ToString();
    }
    private void ResetCollectibles()
    {
        collectibles.coins = 0;
        collectibles.candies = 0;
    }
    public void AddCoins(int value)
    {
        collectibles.coins += value;
    }
    public void AddCandies(int value)
    {
        collectibles.candies += value;
    }
}