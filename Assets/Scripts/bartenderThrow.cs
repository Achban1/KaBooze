using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartenderThrow : MonoBehaviour
{
    public GameObject[] GlassBottles;
    public GameObject MolotovPrefab;
    public GameObject MolotovPrefab2;
    float timer = 0.0f;
    float rageTimer;
    float fireRate;

    public Transform playerPos;
    public bool Mode;
    float ti;
    float fast;
    private Animator anim;

    public AudioScriptPlayOnAwake audioScript;
    
    // Start is called before the first frame update
    void Start()
    {
        ti = Random.Range(10, 17);
        fast = 5;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mode == false)
        {
            
            if (fast > 4)
            {
                anim.SetTrigger("TrBartender");
                fireRate = 0.8f;
                
            }
            else if (fast <= 4)
            {
                anim.SetTrigger("TrBartenderFast");
                fireRate = 0.1f;
            }
            
        }
        

        if (rageTimer > ti)
        {
            anim.ResetTrigger("TrBartender");
            anim.ResetTrigger("TrBartenderFast");
            fireRate = 100;
            anim.SetTrigger("TrRummage");
            if (rageTimer > ti + 5)
            {
                anim.ResetTrigger("TrRummage");
                anim.SetTrigger("TrRampage");
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


    void Rage()
    {
        
        Mode = true;
        fireRate = 0.08f;
        if (rageTimer > ti + 15)
        {
            
            fast = Random.Range(1, 10);
            Mode = false;
            rageTimer = 0;
        }
    }

}
