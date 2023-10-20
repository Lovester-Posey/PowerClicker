using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum UpgradeType
{
    PowerPerClick,
    PowerPerSecond
}
public class UpgradeButton : MonoBehaviour
{

    [SerializeField] public TMP_Text levelText;
    [SerializeField] public TMP_Text priceText;
    [SerializeField] public GameManager gameManager;

    public int level;
    private int price;
    [SerializeField] private int upgradeCost;

    public UpgradeType upgrade;

    // Update is called once per frame
    void Update()
    {
        //update level text
        levelText.text = level.ToString();

        //calculate the current price
        price = (level + 1) * upgradeCost;

        //update the price text
        priceText.text = price.ToString();

        //change the color of the texted based on if the player can afford it
       /* if (gameManager.totalClicks < price)
        {
            priceText.color = Color.red;
        }
        else
        {
            priceText.color = Color.green;
        }*/

        //(Teneary Operator) Thing we want to see = <Boolean condition> ? <value if true> : <value if fasle>
        priceText.color = gameManager.totalClicks < price ? Color.red : Color.green;
    }

    public void OnUpgradeClick()
    {
        if(gameManager.TryToBuyUpgrade(price, upgrade))
        {
            level++;
            gameManager.totalClicks -= price;
            
        }
    }


}
