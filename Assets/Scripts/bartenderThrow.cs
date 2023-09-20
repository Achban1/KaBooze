using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartenderThrow : MonoBehaviour
{
    public GameObject[] GlassBottles;
    public GameObject MolotovPrefab;
    float timer = 0.0f;
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
            fireRate = 1.2f;
        }

        if (rageTimer > 20)
        {


            fireRate = 100f;
            Debug.Log("Reloading!");
            if (rageTimer > 10)
            {
                Rage();
                
            }

            
        }


        
        if (timer > fireRate)
        {
            int randomGlassIndex = Random.Range(0, GlassBottles.Length);
            GameObject selectedGlassBottle = GlassBottles[randomGlassIndex];
            Instantiate(selectedGlassBottle, transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;
        rageTimer += Time.deltaTime;


    }

    private void Reload()
    {
        
        for (float i = 0; i < 5; i += 1f * Time.deltaTime) 
        { 
            Debug.Log(i);
        }

    }
    void Rage ()
    {
        Mode = true;
        fireRate = 0.05f;
        if (rageTimer > 25)
        {
            Mode = false;
            rageTimer = 0;
            Reload();
        }
    }
}
