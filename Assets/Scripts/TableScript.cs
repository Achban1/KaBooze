using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public CoinCounterScript CoinCounterScript;
    public PlayerHealthScript health;
    public GameObject[] AngryBum;    
    public Player player;

    public int bumCount = 1;
    public float bumTimer;
    public int cash = 0;    

    float stepCat = 0;
    float oneTime = 0;

    Vector3 chair1;
    Vector3 chair2;
    Vector3 chair3;
    int randomMob;    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        CoinCounterScript = GameObject.FindGameObjectWithTag("CoinCounterCanvas").GetComponent<CoinCounterScript>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();    
        chair1 = this.transform.GetChild(0).transform.position;
        chair2 = this.transform.GetChild(1).transform.position;
        chair3 = this.transform.GetChild(2).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        stepCat = player.StepOnCat;
        if (stepCat == 1 && oneTime == 0)
        {
            randomMob = Random.Range(0, 5);
            GameObject selectedMob = AngryBum[randomMob];
            GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
            randomMob = Random.Range(0, 5);
            GameObject selectedMob2 = AngryBum[randomMob];
            GameObject newMob2 = Instantiate(selectedMob2, chair2, transform.rotation);
            randomMob = Random.Range(0, 5);
            GameObject selectedMob3 = AngryBum[randomMob];
            GameObject newMob3 = Instantiate(selectedMob3, chair3, transform.rotation);
            oneTime = 1;
        }
        if (bumTimer < 10 && bumCount <= 3)
        {
            bumTimer += Time.deltaTime;
        }
        else
        {
            bumCount++;
            bumTimer = 0;
        }        

    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == 3 && bumCount != 0)
        {
            if (bumCount == 1)
            {
                cash = 1;
                randomMob = Random.Range(0, 5);
                GameObject selectedMob = AngryBum[randomMob];
                GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
                    
            }
            else if (bumCount == 2)     
            {
                cash = 3;
                randomMob = Random.Range(0, 5);
                GameObject selectedMob = AngryBum[randomMob];
                GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
                randomMob = Random.Range(0, 5);
                GameObject selectedMob2 = AngryBum[randomMob];
                GameObject newMob2 = Instantiate(selectedMob2, chair2, transform.rotation);                    
            }
            else if(bumCount >= 3)
            {
                cash = 5;
                randomMob = Random.Range(0, 5);
                GameObject selectedMob = AngryBum[randomMob];
                GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
                randomMob = Random.Range(0, 5);
                GameObject selectedMob2 = AngryBum[randomMob];
                GameObject newMob2 = Instantiate(selectedMob2, chair2, transform.rotation);
                randomMob = Random.Range(0, 5);
                GameObject selectedMob3 = AngryBum[randomMob];
                GameObject newMob3 = Instantiate(selectedMob3, chair3, transform.rotation);                    
            }            
            
            health.collectedCash = health.collectedCash + cash;
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin(cash);            
            bumCount = 0;
            cash = 0;

        }

    }   

}
