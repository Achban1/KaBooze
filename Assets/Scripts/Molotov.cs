using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Molotov : MonoBehaviour
{
    private int speed = 4;
    private Rigidbody2D rb20;
    private Vector3 destination;
    public Transform playerPos;
    public bool rageMode;
    public GameObject GlassArea;
    public GameObject Explosion;

    public bartenderThrow Mode;
    private float rotationSpeed;
<<<<<<< HEAD
    //public AudioScriptGlassBottle audioScriptGlassBottle;
=======
    public AudioSourcePoolBottles audioSourcePoolBottles;
>>>>>>> 955f83f1227f3ced2df3fc7e3302f4eb2646073e
    public Sprite typeOfExplosion;

    void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb20 = GetComponent<Rigidbody2D>();
        Mode = GameObject.FindGameObjectWithTag("Bartender").GetComponent<bartenderThrow>();
<<<<<<< HEAD
        //audioScriptGlassBottle = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioScriptGlassBottle>();
=======
        audioSourcePoolBottles = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSourcePoolBottles>();
>>>>>>> 955f83f1227f3ced2df3fc7e3302f4eb2646073e
        
        

        // Set destination based on rage modes
        if (Mode.Mode)
        {
            SetRandomDestination();
        }
        else if (!Mode.Mode)
        {
            
            SetPlayerDestination();
        }

        if (destination.x > 0)
        {
            rotationSpeed -= 250;
        }
        else if (destination.x < 0)
        {
            rotationSpeed += 250;
        }
        


        Destroy(gameObject, 3);

    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);


        Vector2 direction = destination - transform.position;
        rb20.velocity = direction.normalized * speed;

        // Destroy if close to the destination
        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {           
            Destroy(gameObject);
            Instantiate(GlassArea, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.identity);
            GameObject newExplosion  = Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(newExplosion, 0.4f);
            
            newExplosion.GetComponent<SpriteRenderer>().material.color = new Color(Random.Range(0.5f, 1), 0, 0);

        }
    }

    private void SetRandomDestination()
    {
        Camera cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;
        destination = new Vector2(Random.Range(-width+0.5f, width-0.5f), Random.Range(-height + 0.5f, height-3));
    }

    private void SetPlayerDestination()
    {
        destination = playerPos.position;
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.layer == 7 || col.gameObject.layer == 6)
        {

<<<<<<< HEAD
            //audioScriptGlassBottle.GlassBreakSound();
=======
            audioSourcePoolBottles.BottleSoundFX();
>>>>>>> 955f83f1227f3ced2df3fc7e3302f4eb2646073e
            Destroy(gameObject);
            
        }
    }

}