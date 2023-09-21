using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public CoinCounterScript CoinCounterScript;
    public PlayerHealthScript health;
    public GameObject []AngryBum;
    public AngryBumScript AngryBumScript;
    public float bumCount = 1;
    public float bumTimer;
    public float cash = 0;
    public float bumPosX = -0.5f;
    public float bumPosY = 0;
    public float ThistableNr = 0;
    public float tableBumped = 0;

    public Vector3 tablePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        CoinCounterScript = GameObject.FindGameObjectWithTag("CoinCounterCanvas").GetComponent<CoinCounterScript>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        cash = 1;
        tablePos = new Vector3 (transform.position.x, transform.position.y , 0);        
    }

    // Update is called once per frame
    void Update()
    {
        if (bumTimer < 5)
        {
            bumTimer += Time.deltaTime;
        }
        else if (bumCount < 4) 
        {
            //Setting bumPosY to avoid bump while bumPosX is 0
            if (bumPosX == 0)
            {
                bumPosY = -0.3f;
            }
            else
            {
                bumPosY = 0;
            }
            bumSpawn();
            bumPosX += 0.5f;
            bumCount++;
            bumTimer = 0;   
        }
        if (bumTimer > 10)
        {
            cash += Random.Range(2, 8);
        }
        switch (bumCount)
        {
            case 1:
                {
                    tablePos = transform.position;
                    tablePos = new Vector3(tablePos.x + 0.246f, tablePos.y + -0.034f, 0);
                    break;
                }
            case 2:
                {
                    tablePos = transform.position;
                    tablePos = new Vector3(tablePos.x - 0.013f, tablePos.y - 0.207f, 0);
                    break;
                }
            case 3:
                {
                    tablePos = transform.position;
                    tablePos = new Vector3(tablePos.x - 0.299f, tablePos.y  -0.14f, 0);
                    break;
                }
        }
        
        //if (bumCount < 5)
        //{
        //    int randomMob = Random.Range(0, 5);
        //    GameObject selectedMob = AngryBum[randomMob];
        //    Instantiate(selectedMob, new Vector3(0, -4.5f, 0), transform.rotation);
        //    bumCount++;
        //}

    }
    private void bumSpawn()
    {
        int randomMob = Random.Range(0, 5);
        GameObject selectedMob = AngryBum[randomMob];
        GameObject newMob = Instantiate(selectedMob, new Vector3(0, -4.5f, 0), transform.rotation);
        newMob.GetComponent<AngryBumScript>().myTable = tablePos;
        //Setting tablenumber for bumping Table
        newMob.GetComponent<AngryBumScript>().tableNr = ThistableNr;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change to playerLayer
        if (collision.gameObject.layer == 3 ) //&& bumCount < 2) 
        {
           
            bumCount++;
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin();            
        }
        if (collision.gameObject.layer == 3)
        {
            tableBumped = ThistableNr;
            health.collectedCash = health.collectedCash + cash;
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin();
            //Telling AngryBums that someone stole their tip
            
        }

    }
     
}
