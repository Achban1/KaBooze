using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public Rigidbody2D Barman;
    public PlayerHealthScript health;
    public SpriteRenderer spriteRenderer;
    public CameraScript CameraScript;
    public Animator animator;
    public AudioScriptPunchSound AudioScriptPunchSound;
    public AudioScriptPlayerDeathSound audioScriptPlayerDeathSound;
    public bool playerIsAlive = true;
    public float heroSpeed = 5f;
    public GameObject dyingPlayer;  
    public GameObject Cat;
    public GameObject BigCat;
    private SpriteRenderer CatRender;

    Vector2 rawInput;
    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        CameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        AudioScriptPunchSound = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioScriptPunchSound>();
        audioScriptPlayerDeathSound = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioScriptPlayerDeathSound>();
        CatRender = Cat.GetComponent<SpriteRenderer>();
        


    }

    // Update is called once per frame
    void Update()
    {
                        
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");        

        if (rawInput.x != 0)
        {
            animator.SetFloat("movingX", rawInput.x);
            animator.SetFloat("movingY", 0);
        }
        else
        {
            animator.SetFloat("movingY", rawInput.y);
            animator.SetFloat("movingX", 0);
        }
        if (rawInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if(rawInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (rawInput.sqrMagnitude > 1)
        {
            rawInput.Normalize();
        }
        if (playerIsAlive)
        {
            velocity = rawInput * (heroSpeed * Time.deltaTime);
            transform.position += velocity;
        }     

        if (health._currentHealth <= 0 && playerIsAlive)
        {
            audioScriptPlayerDeathSound.PlayerDeathSoundFX();
            playerIsAlive = false;
            Debug.Log("You dead");
            animator.SetBool("alive", false);            
        }     
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && playerIsAlive)
        {

            Debug.Log("Damage Taken");
            health.PlayerDamage(5);
            AudioScriptPunchSound.PunchSound();
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

        if (collision.gameObject == Cat)
        {
            Instantiate(BigCat, new Vector3(1,4.2f,0), Quaternion.identity);
            CatRender.color = new Color(0, 0, 0, 0);
        }

    }
    private void BackToWhite()
    {
        spriteRenderer.color = Color.white;
    }
}

