using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinCounterScript : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    private int coinCount;

    void Start()
    {
        coinCount = 0;
        UpdateCoinCountUI();
    }

    public void CollectCoin()
    {
        Debug.Log("CollectCoinVoid");
        coinCount++;
        UpdateCoinCountUI();
    }

    void  UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }

}
