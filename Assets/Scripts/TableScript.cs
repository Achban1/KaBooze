using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public PlayerHealthScript health;
    public GameObject AngryBum;
    public float bumCount;
    public float bumTimer;
    public float cash = 0;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        cash += Random.Range(2, 8);
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
        }
        if (collision.gameObject.layer == 3)
        {
            health.collectedCash = health.collectedCash + cash;
        }

    }
}
