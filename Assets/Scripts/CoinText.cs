using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    // Start is called before the first frame update


    public void IncrementCoinCount(int coinTotal)
    {
        coinText.text = "Highscore:" + coinTotal.ToString();
    }
}
