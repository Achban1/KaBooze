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
    public float lastX = 0;
    public float currentX = 0;
    public float movingX = 0;
    public float lastY = 0;
    public float currentY = 0;
    public float movingY = 0;
    public Animator animator;
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
        //currentX = transform.position.x;
        //currentY = transform.position.y;        
                
        //movingY = currentY - lastY;
        //movingX = currentX - lastX;
        
        //if (Mathf.Abs(movingX) > Mathf.Abs(movingY))
        //{
        //    animator.SetFloat("movingX", movingX);
        //    animator.SetFloat("movingY", 0);
        //}
        //else
        //{
        //    animator.SetFloat("movingY", movingY);
        //    animator.SetFloat("movingX", 0);
        //}
        
        //lastY = currentY;
        //lastX = currentX;
        Vector2 direction = target.position - transform.position;


        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            animator.SetFloat("movingX", direction.x);
            animator.SetFloat("movingY", 0);
        }
        else
        {
            animator.SetFloat("movingY", direction.y);
            animator.SetFloat("movingX", 0);
        }
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX= false;
        }


        direction.Normalize();

        rb2D.velocity = direction * speed;

        //transform.right = direction;

        if (bumHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            
            Destroy(gameObject, 1);
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
  