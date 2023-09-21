using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public PlayerHealthScript health;
    public GameObject []AngryBum;
    public float bumCount =1;
    public float bumTimer;
    public float cash = 0;
    public CoinCounterScript CoinCounterScript;
    public float bumPosX = -0.5f;
    public float bumPosY = 0;

    public Vector3 tablePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        CoinCounterScript = GameObject.FindGameObjectWithTag("CoinCounterCanvas").GetComponent<CoinCounterScript>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        cash = 1;
        tablePos = new Vector3 (transform.position.x, transform.position.y - 0.2f, 0);
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
            //if (bumPosX == 0) 
            //{ 
            //    bumPosY = -0.3f;
            //}
            //else
            //{
            //    bumPosY = 0;
            //}
            bumSpawn();
            bumPosX += 0.5f;
            bumCount++;
            bumTimer = 0;   
        }
        if (bumTimer > 10)
        {
            cash += Random.Range(2, 8);
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
        //Ändra här
        if (bumCount == 1)
        {
            newMob.GetComponent<AngryBumScript>().myTable = new Vector3(tablePos.x + 0.031f, tablePos.y + -0.192f, 0);
        }
        else if(bumCount == 2)
        {
            newMob.GetComponent<AngryBumScript>().myTable = new Vector3(tablePos.x + -0.268f, tablePos.y + -0.125f, 0);
        }
        else if (bumCount == 3)
        {
            newMob.GetComponent<AngryBumScript>().myTable = new Vector3(tablePos.x + 0.232f, tablePos.y + -0.058f, 0);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change to playerLayer
        if (collision.gameObject.layer == 3 ) //&& bumCount < 2) 
        {
            Invoke("bumSpawn", 1);
            bumCount++;
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin();            
        }
        if (collision.gameObject.layer == 3)
        {
            health.collectedCash = health.collectedCash + cash;
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin();
        }

    }
     
}
