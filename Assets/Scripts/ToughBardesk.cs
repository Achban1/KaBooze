using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToughBardesk : MonoBehaviour
{
    public CoinCounterScript coin;
    int coinCount;
    public GameObject VictoryMenu;
    public GameObject VictorySquare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin = GameObject.FindGameObjectWithTag("CoinCounterCanvas").GetComponent<CoinCounterScript>();
        coinCount = coin.coinCount;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (coinCount >= 10)
        {

            VictorySquare.SetActive(true);
            if (coinCount >= 10 && col.gameObject.layer == 8)
            {
                
                SwitchToVictory();
            }
            
        }
    }

    public void SwitchToVictory()
    {
        VictoryMenu.SetActive(true);
        
        Invoke("quit", 1);
        Time.timeScale = 0.1f;


    }
    private void quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }


}
