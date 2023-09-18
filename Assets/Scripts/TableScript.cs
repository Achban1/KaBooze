using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    
    public GameObject AngryBum;
    public float bumCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change to playerLayer
        if (collision.gameObject.layer == 3 && bumCount < 2) 
        {
            Instantiate(AngryBum, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            bumCount++;
        }
    }
}
