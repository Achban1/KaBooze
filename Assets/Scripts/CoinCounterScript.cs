using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CoinCounterScript : MonoBehaviour
{
    public AudioScriptCoinCollected audioScriptCoinCollected;
    public TextMeshProUGUI coinCountText;
    public int coinCount;
    [SerializeField] CoinText coinText;
    public GameObject player;
    public GameObject barDesk;
    void Start()
    {
        coinCount = 0;
        UpdateCoinCountUI();
        audioScriptCoinCollected = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioScriptCoinCollected>();
    }

    public int CollectCoin(int cash)
    {
        
        Debug.Log("CollectCoinVoid");
        coinCount += cash;
        audioScriptCoinCollected.CoinCollectSoundFX();
        UpdateCoinCountUI();
        return coinCount;

    }

    void  UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + coinCount.ToString() + "/30";

        
    }




}
