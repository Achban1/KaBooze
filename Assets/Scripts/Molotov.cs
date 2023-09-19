using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Molotov : MonoBehaviour
{

    private int speed = 10;
    Rigidbody2D rb20;
    private float height;
    private float width;
    private Vector3 randomDestination;
    public Transform playerPos;
    public bool rageMode;
    Vector3 savedPlayerPos;


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
        direction.Normalize();

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
        direction.Normalize();

        if (transform.position != savedPlayerPos)
        {
            rb20.velocity = direction * speed;
        }


        if (transform.position == savedPlayerPos)
        {
            Debug.Log("Hit");
            Destroy(gameObject);

        }
        Debug.Log(transform.position);
        Debug.Log(savedPlayerPos);


    }

}
