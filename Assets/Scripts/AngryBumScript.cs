using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBumScript : MonoBehaviour
{
    public float speed = 3;
    public GameObject AngryBum;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteList;  

    Transform target;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
        changeSprite();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = target.position - transform.position;

        direction.Normalize();

        rb2D.velocity = direction * 3;

        transform.right = direction;

    }
    void changeSprite()
    {
        int newSprite = Random.Range(0, 4); 
        spriteRenderer.sprite = spriteList[newSprite];
    }
}
  