using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngryBumScript : MonoBehaviour
{
    public float speed = 3;
    public int bumHealth = 2;
    //public GameObject AngryBum;
    public SpriteRenderer spriteRenderer;
    //public Sprite[] spriteList;  

    Transform target;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        bumHealth =+ Random.Range(0,4);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
       // changeSprite();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = target.position - transform.position;

        direction.Normalize();

        rb2D.velocity = direction * speed;

        transform.right = direction;

        if (bumHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //Damadge player
        }
        if (collision.gameObject.layer == 6)
        {
            spriteRenderer.color = Color.red;
            //Damadge both Bums
            Invoke("BackToWhite", 0.3f);
            bumHealth--;
        }
    }
    
    //void changeSprite()
    //{
    //    int newSprite = Random.Range(0, 4); 
    //    spriteRenderer.sprite = spriteList[newSprite];
    //}
    private void BackToWhite()
    {
        spriteRenderer.color = Color.white;
    }
}
  