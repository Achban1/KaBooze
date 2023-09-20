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
    private Rigidbody2D rb20;
    private Vector3 destination;
    public Transform playerPos;
    public bool rageMode;
    public GameObject GlassArea;
    public bartenderThrow Mode;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb20 = GetComponent<Rigidbody2D>();

        // Set destination based on rage mode
        if (rageMode)
            SetRandomDestination();
        else
            SetPlayerDestination();
    }

    void Update()
    {
        // Move towards the destination
        Vector2 direction = destination - transform.position;
        rb20.velocity = direction.normalized * speed;

        // Destroy if close to the destination
        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {
            Destroy(gameObject);
            Instantiate(GlassArea, transform.position, transform.rotation);
        }
    }

    private void SetRandomDestination()
    {
        Camera cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;
        destination = new Vector2(Random.Range(-width, width), Random.Range(-height, height));
    }

    private void SetPlayerDestination()
    {
        destination = playerPos.position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.layer == 7 || col.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
}