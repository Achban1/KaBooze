using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D Barman;
    public PlayerHealthScript health;

    public bool playerIsAlive = true;
    public float heroSpeed = 5f;
   
    Vector2 rawInput;
    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
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

        velocity = rawInput * (heroSpeed * Time.deltaTime);
        transform.position += velocity;

        if (health._currentHealth <= 0)
        {                
            Debug.Log("You dead");
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Damage Taken");
            health.PlayerDamage(5);
        }
    }
}
