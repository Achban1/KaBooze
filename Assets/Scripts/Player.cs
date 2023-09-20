using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D Barman;
    public PlayerHealthScript health;
    public SpriteRenderer spriteRenderer;
    public CameraScript CameraScript;
    
    public bool playerIsAlive = true;
    public float heroSpeed = 5f;
    public GameObject dyingPlayer;
    
   
    Vector2 rawInput;
    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        CameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
                        
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

        if (rawInput.sqrMagnitude > 1)
        {
            rawInput.Normalize();
        }
        if (playerIsAlive )
        {
            velocity = rawInput * (heroSpeed * Time.deltaTime);
            transform.position += velocity;
        }

        if (health._currentHealth <= 0 && playerIsAlive)
        {
            playerIsAlive = false;
            Debug.Log("You dead");            
            Instantiate(dyingPlayer, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
        if (playerIsAlive == false)
        {
            spriteRenderer.color = new Color(0,0,0,0);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && playerIsAlive)
        {

            Debug.Log("Damage Taken");
            health.PlayerDamage(5);
            spriteRenderer.color = Color.red;            
            CameraScript.Shake();
            Invoke("BackToWhite", 0.1f);
        }
        if (collision.gameObject.layer == 9 && playerIsAlive)
        {
            Debug.Log("Damage Taken");
            health.PlayerDamage(10);
            spriteRenderer.color = Color.red;
            CameraScript.Shake();
            Invoke("BackToWhite", 0.1f);
        }
    }
    private void BackToWhite()
    {
        spriteRenderer.color = Color.white;
    }
}

