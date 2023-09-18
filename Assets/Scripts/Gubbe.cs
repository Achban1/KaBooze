using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMan : MonoBehaviour
{
    public Rigidbody2D Barman;
    Rigidbody2D Gubben;
    public float heroSpeed = 0.001f;
    Vector2 position = Vector2.zero;
    Vector2 rawInput;
    Vector2 velocity;


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
        position += velocity;

        transform.position = position;
    }
}
