using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public PlayerHealthScript health;
    public GameObject AngryBum;
    public float bumCount;
    public float bumTimer;
    public float cash = 0;
    public CoinCounterScript CoinCounterScript;

    // Start is called before the first frame update
    void Start()
    {
        CoinCounterScript = GameObject.FindGameObjectWithTag("CoinCounterCanvas").GetComponent<CoinCounterScript>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        cash = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (bumTimer < 20)
        {
            bumTimer += Time.deltaTime;
        }
        else
        {
            bumCount = 0;
            bumTimer = 0;
        }
        if (bumTimer > 17)
        {
            cash += Random.Range(2, 8);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change to playerLayer
        if (collision.gameObject.layer == 3 && bumCount < 2) 
        {
            Instantiate(AngryBum, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
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
