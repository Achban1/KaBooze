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
    float t;
    float u;


    // Start is called before the first frame update
    void Start()
    {
        t = Random.Range(10, 17);
        u = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mode == false)
        {
            if (u > 4)
            {
                fireRate = 1.2f;
            }
            else if (u <= 4)
            {
                fireRate = 0.1f;
            }

        }
        

        if (rageTimer > t)
        {
            fireRate = 100;
            if (rageTimer > t + 5)
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

    private IEnumerator WaitAndReload(float seconds)
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
    }

    void Rage()
    {
        Mode = true;
        fireRate = 0.05f;
        if (rageTimer > t + 15)
        {
            u = Random.Range(1, 10);
            Mode = false;
            rageTimer = 0;
        }
    }

}
