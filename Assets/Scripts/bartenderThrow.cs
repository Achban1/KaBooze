using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartenderThrow : MonoBehaviour
{
    public GameObject MolotovPrefab;
    float timer;

    public Transform playerPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 0.2f)
        {

            Instantiate(MolotovPrefab, transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;

    }
}
