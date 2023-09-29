using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CoinCounterScript : MonoBehaviour
{
    public AudioScriptPlay audioScriptPlay;
    public TextMeshProUGUI coinCountText;
    public int coinCount;
    [SerializeField] CoinText coinText;
    public GameObject player;
    public GameObject barDesk;
    void Start()
    {
        coinCount = 0;
        UpdateCoinCountUI();
        audioScriptPlay = GameObject.FindGameObjectWithTag("CoinPickUpAudio").GetComponent<AudioScriptPlay>();
    }

    public int CollectCoin(int cash)
    {
        
        Debug.Log("CollectCoinVoid");
        coinCount += cash;
        audioScriptPlay.PlayAuido();
        UpdateCoinCountUI();
        return coinCount;

    }

    void  UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + coinCount.ToString() + "/30";

        
    }




}
