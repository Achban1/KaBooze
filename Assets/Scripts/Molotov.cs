using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Molotov : MonoBehaviour
{

    private int speed = 2;
    Rigidbody2D rb20;

    private float height;
    private float width;
    private Vector3 randomDestination;
    private Vector3 savedPlayerPos;
    public Transform playerPos;
    public bool rageMode;
    public GameObject GlassArea;
    public bartenderThrow Mode;



    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        savedPlayerPos = playerPos.position;
        rb20 = GetComponent<Rigidbody2D>();

        
        Camera cam = Camera.main;
        height = cam.orthographicSize;
        width = height * cam.aspect;
        randomDestination = new Vector2(Random.Range(-width, width), Random.Range(-height, height));

        Mode = GameObject.FindGameObjectWithTag("Bartender").GetComponent<bartenderThrow>();

        if (randomDestination.sqrMagnitude < 16)
        {
            Destroy(gameObject);
        }
        

    }

    void Update()
    {

       if (Mode.Mode == true)
       {
            Rage();

       } 
       else
       {
            Normal();
       }

    }

    private void Rage()
    {

        Vector2 direction = randomDestination - transform.position;
        
        if (transform.position.sqrMagnitude <= direction.sqrMagnitude)
        {
            rb20.velocity = direction * speed;
        }

        if (transform.position.sqrMagnitude > randomDestination.sqrMagnitude)
        {
            Destroy(gameObject);
            Instantiate(GlassArea, transform.position, transform.rotation);           
        }
    }

    private void Normal()
    {
        
        Vector2 direction = savedPlayerPos - transform.position;
        

        if (rb20.velocity.sqrMagnitude <= direction.sqrMagnitude)
        {
            rb20.velocity = direction * speed;
        }

        if (transform.position == savedPlayerPos)
        {
            Destroy(gameObject);
            Instantiate(GlassArea, transform.position, transform.rotation);

        }


    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.layer == 7 || col.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }

    }

}
