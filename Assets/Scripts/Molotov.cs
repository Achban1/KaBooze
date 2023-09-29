using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Molotov : MonoBehaviour
{

    private Vector3 destination;
    public Transform playerPos;
    private int speed = 4;
    private Rigidbody2D rb20;
    private float rotationSpeed;


    public AudioScriptPlay audioScriptPlay;

    [Header("Objects")]
    public GameObject GlassArea;
    public GameObject Explosion;
    public Sprite typeOfExplosion;

    [Header("Bools")]
    public bool rageMode;
    public BartenderThrow Mode;


    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Mode = GameObject.FindGameObjectWithTag("Bartender").GetComponent<BartenderThrow>();
        rb20 = GetComponent<Rigidbody2D>();

        audioScriptPlay = GameObject.FindGameObjectWithTag("BottlesAudio").GetComponent<AudioScriptPlay>();
        
        MolotovRotationDirection();
        SetDestinationOfMolotov();

        Destroy(gameObject, 3);
    }


    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        Vector2 direction = destination - transform.position;
        rb20.velocity = direction.normalized * speed;

        if (Vector2.Distance(transform.position, destination) < 0.1f)
        {           
            Destroy(gameObject);
            Instantiate(GlassArea, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            GameObject newExplosion  = Instantiate(Explosion, transform.position, Quaternion.identity);
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

    private void SetDestinationOfMolotov()
    {
        if (Mode.Mode)
        {
            SetRandomDestination();
        }
        else if (!Mode.Mode)
        {

            destination = playerPos.position;
        }
    }

    private void MolotovRotationDirection()
    {
        if (destination.x > 0)
        {
            rotationSpeed -= 250;
        }
        else if (destination.x < 0)
        {
            rotationSpeed += 250;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.layer == 7 || col.gameObject.layer == 6)
        {           
            audioScriptPlay.PlayAuido();
            Destroy(gameObject);       
        }
    }

}