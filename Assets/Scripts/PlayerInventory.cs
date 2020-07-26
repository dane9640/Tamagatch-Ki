using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ]
public class PlayerInventory : ScriptableObject
{
    private static int totalCoins;

    public void SetTotalCoins(int value)
    {
        totalCoins = value;
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    //Adds coins to total amount.
    public void AddCoins(int coins)
    {
        SetTotalCoins(totalCoins += coins);
    }
}
