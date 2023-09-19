using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartenderThrow : MonoBehaviour
{
    public GameObject MolotovPrefab;
    float timer;
    float rageTimer;
    float fireRate;
    public Transform playerPos;
    public bool Mode;



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Mode == false)
        {
            fireRate = 2;
        }

        if (rageTimer > 10)
        {
            Mode = true;

            fireRate = 0.2f;
            if (rageTimer > 11)
            {
                rageTimer = 0;
            }
            
        }



        if (timer > fireRate)
        {

            Instantiate(MolotovPrefab, transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;
        rageTimer += Time.deltaTime;

    }
}
