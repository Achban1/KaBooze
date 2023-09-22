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

    public void CollectCoin()
    {
        Debug.Log("CollectCoinVoid");
        coinCount++;
        audioScriptCoinCollected.CoinCollectSoundFX();
        UpdateCoinCountUI();
    }

    void  UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + coinCount.ToString() + "/30";

        
    }




}
