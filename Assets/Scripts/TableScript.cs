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

    float stepOnCat = 0;
    float oneTime = 0;
       
    int randomMob;    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        CoinCounterScript = GameObject.FindGameObjectWithTag("CoinCounterCanvas").GetComponent<CoinCounterScript>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();           
    }

    // Update is called once per frame
    void Update()
    {
        stepOnCat = player.StepOnCat;
        if (stepOnCat == 1 && oneTime == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                randomMob = Random.Range(0, 5);
                GameObject selectedMob = AngryBum[randomMob];
                GameObject newMob = Instantiate(selectedMob, this.transform.GetChild(i).transform.position, 
                    transform.rotation);
            }            
            oneTime = 1;
        }
        if (bumTimer < 10 && bumCount < 3)
        {
            bumTimer += Time.deltaTime;            
        }
        else
        {
            bumCount++;
            bumTimer = 0;            
        }        
        if (bumCount > 3)
        {
            bumCount = 3;            
        }
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.layer == 3 && bumCount != 0)
        {
            cash = ((bumCount * bumCount) -(bumCount - 1));
            health.collectedCash = health.collectedCash + cash;
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin(cash);

            for (int i = 0; i < bumCount; i++)
            {
                randomMob = Random.Range(0, 5);
                GameObject selectedMob = AngryBum[randomMob];
                GameObject newMob = Instantiate(selectedMob, this.transform.GetChild(i).transform.position, 
                    transform.rotation);                
            }                        
            bumCount = 0;                 
        }
    }       
}
