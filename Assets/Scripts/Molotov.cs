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
    public GameObject player;
    public Transform playerPos;
    public bool rageMode;



    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        savedPlayerPos = playerPos.position;
        rb20 = GetComponent<Rigidbody2D>();

        
        Camera cam = Camera.main;

        height = cam.orthographicSize;
        width = height * cam.aspect;


        randomDestination = new Vector2(Random.Range(-width, width), Random.Range(-height, height));

    }

    void Update()
    {

        Normal();
        

    }

    private void Rage()
    {

        Vector2 direction = randomDestination - transform.position;
        rb20.velocity = rb20.velocity.normalized;

        if (transform.position != randomDestination)
        {
            rb20.velocity = direction * speed;
        }


        if (transform.position.sqrMagnitude >= randomDestination.sqrMagnitude)
        {
            Debug.Log("Hit");
            Destroy(gameObject);

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
            Debug.Log("Hit");
            Destroy(gameObject);

        }


        //if (transform.position.magnitude - savedPlayerPos.magnitude < 0)
        //{

        //    Debug.Log("Hit");
        //    Destroy(gameObject);

        //}
        


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
