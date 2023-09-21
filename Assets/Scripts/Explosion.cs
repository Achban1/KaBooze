using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        
        GetComponent<SpriteRenderer>().material.color = new Color(1, 0, 0);

    }
}
