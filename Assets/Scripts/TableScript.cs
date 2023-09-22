using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public CoinCounterScript CoinCounterScript;
    public PlayerHealthScript health;
    public GameObject[] AngryBum;
    public AngryBumScript AngryBumScript;
    public float bumCount = 1;
    public float bumTimer;
    public float cash = 0;
    public float ThisTableNr = 0;
    public float tableBumped = 0;
    Vector3 chair1;
    Vector3 chair2;
    Vector3 chair3;
    int randomMob;

    public Vector3 tablePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        CoinCounterScript = GameObject.FindGameObjectWithTag("CoinCounterCanvas").GetComponent<CoinCounterScript>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        cash = 1;
        tablePos = new Vector3(transform.position.x, transform.position.y, 0);
        chair1 = this.transform.GetChild(0).transform.position;
        chair2 = this.transform.GetChild(1).transform.position;
        chair3 = this.transform.GetChild(2).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bumTimer < 10 && bumCount <= 3)
        {
            bumTimer += Time.deltaTime;
        }
        else
        {
            bumCount++;
            bumTimer = 0;
        }
        //else if (bumCount < 4)
        //{
        //    bumSpawn();
        //    bumCount++;
        //    bumTimer = 0;
        //}        
        switch (bumCount)
        {
            case 1:
                {
                    tablePos = transform.position;
                    tablePos = chair1;
                    break;
                }
            case 2:
                {
                    tablePos = transform.position;
                    tablePos = chair2;
                    break;
                }
            case 3:
                {
                    tablePos = transform.position;
                    tablePos = chair3;
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
    //private void bumSpawn()
    //{
    //    int randomMob = Random.Range(0, 5);
    //    GameObject selectedMob = AngryBum[randomMob];
    //    GameObject newMob = Instantiate(selectedMob, new Vector3(0, -4.5f, 0), transform.rotation);
    //    newMob.GetComponent<AngryBumScript>().myTable = tablePos;
    //    //Setting tablenumber for bumping Table
    //    newMob.GetComponent<AngryBumScript>().tableNr = ThisTableNr;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change to playerLayer
        if (collision.gameObject.layer == 3) //&& bumCount < 2) 
        {            
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin();
        }
        if (collision.gameObject.layer == 3 && bumCount != 0)
        {
            switch (bumCount)
            {
                case 1:
                {
                    randomMob = Random.Range(0, 5);
                    GameObject selectedMob = AngryBum[randomMob];
                    GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
                    break;
                }
                case 2:
                {
                    randomMob = Random.Range(0, 5);
                    GameObject selectedMob = AngryBum[randomMob];
                    GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
                    randomMob = Random.Range(0, 5);
                    GameObject selectedMob2 = AngryBum[randomMob];
                    GameObject newMob2 = Instantiate(selectedMob2, chair2, transform.rotation);
                    break;
                }
                case 3:
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
                    break;
                }
            }
            //
            //GameObject selectedMob = AngryBum[randomMob];
            //GameObject newMob = Instantiate(selectedMob, tablePos, transform.rotation);
            //tableBumped = ThisTableNr;
            health.collectedCash = health.collectedCash + cash;
            Debug.Log("CoinCollected");
            CoinCounterScript.CollectCoin();
            //Telling AngryBums that someone stole their tip
            bumCount = 1;

        }

    }
    public void spamBum()
    {        
        switch (bumCount)
        {
            case 1:
                {
                    randomMob = Random.Range(0, 5);
                    GameObject selectedMob = AngryBum[randomMob];
                    GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
                    break;
                }
            case 2:
                {
                    randomMob = Random.Range(0, 5);
                    GameObject selectedMob = AngryBum[randomMob];
                    GameObject newMob = Instantiate(selectedMob, chair1, transform.rotation);
                    randomMob = Random.Range(0, 5);
                    GameObject selectedMob2 = AngryBum[randomMob];
                    GameObject newMob2 = Instantiate(selectedMob2, chair2, transform.rotation);
                    break;
                }
            case 3:
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
                    break;
                }
        }
    }

}
