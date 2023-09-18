using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMan : MonoBehaviour
{
    public Rigidbody2D Barman;
    Rigidbody2D Gubben;
    public float heroSpeed = 5f;
   
    Vector2 rawInput;
    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        Gubben = GetComponent<Rigidbody2D>();
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

    }
}
