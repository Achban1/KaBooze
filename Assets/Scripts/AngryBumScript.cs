using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngryBumScript : MonoBehaviour
{
    public TableScript tableScript;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    Transform target;
    Rigidbody2D rb2D;
    BoxCollider2D boxC;

    public float speed = 3;    
    public bool fall;
    public float timer;     

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        tableScript = GameObject.FindGameObjectWithTag("Furniture").GetComponent<TableScript>();
        rb2D = GetComponent<Rigidbody2D>();        
    }
    
    // Update is called once per frame
    void Update()
    {       
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb2D.velocity = direction * speed;

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

        if (fall == true)
        {
            speed = 0;
        }        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            fall = true;
            animator.SetBool("fall", true);
            Destroy(gameObject, 1);
        }
    }
}