using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngryBumScript : MonoBehaviour
{
    public TableScript tableScript;
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
    public float tableBumped;
    public bool heTookMyTip = false;
    public int tableNr;
    public Vector3 myTable;
    Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        tableScript = GameObject.FindGameObjectsWithTag("Furniture")[tableNr-1].GetComponent<TableScript>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
        boxC = GetComponent<BoxCollider2D>();
        boxC.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        tableBumped = tableScript.tableBumped;
        if (timer > 3 || myTable.sqrMagnitude - transform.position.sqrMagnitude < 0.8f)
        {
            boxC.enabled = true;
            speed = 0;
            animator.SetBool("still", true);
        }
        if (tableBumped == tableNr)
        {
            heTookMyTip = true;
        }
        if (heTookMyTip == true)
        {
            direction = target.position - transform.position;
            speed = 2;
            animator.SetBool("still", false);
        }
        else
        {
            direction = myTable - transform.position;
        }
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