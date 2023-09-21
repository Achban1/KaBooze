using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngryBumScript : MonoBehaviour
{
    public float speed = 3;      
    public float movingX = 0;    
    public float movingY = 0;    
    public bool fall;
    public Animator animator;
    public SpriteRenderer spriteRenderer;       
    Transform target;
    Rigidbody2D rb2D;
    BoxCollider2D boxC;
    public float timer;

    public Vector3 myTable;


    // Start is called before the first frame update
    void Start()
    {        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
        boxC = GetComponent<BoxCollider2D>();
        boxC.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {        
        if (timer > 3 || myTable.sqrMagnitude - transform.position.sqrMagnitude < 1 ) 
        {
            boxC.enabled = true;
        }
       //Vector2 direction = target.position - transform.position;
        Vector2 direction = myTable - transform.position;

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
        direction.Normalize();
        rb2D.velocity = direction * speed;
       
        timer += Time.deltaTime;
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