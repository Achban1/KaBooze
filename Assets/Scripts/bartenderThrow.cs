using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartenderThrow : MonoBehaviour
{
    public GameObject MolotovPrefab;
    float timer;
    float rageTimer;
    float fireRate;
    float reload;
    public Transform playerPos;
    public bool Mode;




    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //normal - ´rawand was here
        if (Mode == false)
        {
            fireRate = 1.2f;
        }

        if (rageTimer > 20)
        {
            Rage();
        }


        
        if (timer > fireRate)
        {

            Instantiate(MolotovPrefab, transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;
        rageTimer += Time.deltaTime;
        reload += Time.deltaTime;

    }

    private void Reset()
    {
        
    }
    void Rage ()
    {
        Mode = true;
        fireRate = 0.01f;
        if (rageTimer > 25)
        {
            Mode = false;
            rageTimer = 0;

        }
    }
}
