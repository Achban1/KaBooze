using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartenderThrow : MonoBehaviour
{
    public GameObject MolotovPrefab;
    float timer;
    public float fireRate;
    public Transform playerPos;
    public bool Mode;



    // Start is called before the first frame update
    void Start()
    {
        Mode = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Mode)
        {
            fireRate = 1;
        }

        if (Mode == false)
        {
            fireRate = 0.2f;
        }



        if (timer > fireRate)
        {

            Instantiate(MolotovPrefab, transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;

    }
}
