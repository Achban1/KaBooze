using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngryBumScript : MonoBehaviour
{
    public float speed = 3;
    public int bumHealth = 2;    
    public SpriteRenderer spriteRenderer;     
    public float movingX = 0;    
    public float movingY = 0;
    public bool fall = false;
    public Animator animator;
    Transform target;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        bumHealth = +Random.Range(0, 4);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {           
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
            spriteRenderer.flipX = false;
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
            speed = 0;
            fall = true;
            animator.SetBool("fall", fall);
            Destroy(gameObject, 1);
        }

    }
    private void BackToWhite()
    {
        spriteRenderer.color = Color.white;
    }
}