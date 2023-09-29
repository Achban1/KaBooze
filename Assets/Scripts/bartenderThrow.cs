using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderThrow : MonoBehaviour
{
    public GameObject[] GlassBottles;
    float timer = 0.0f;
    float rageTimer;
    float fireRate;

    public Transform playerPos;
    public bool Mode;
    float randomTime;
    float fastMode;
    private Animator animator;
    

    void Start()
    {
        randomTime = Random.Range(10, 17);
        animator = GetComponent<Animator>();
        fastMode = 5;
    }

 
    void Update()
    {
        
        if (Mode == false)
        {
            FastMode();
        }

        if (rageTimer > randomTime)
        {
            animator.ResetTrigger("TrBartender");
            animator.ResetTrigger("TrBartenderFast");
            fireRate = 100;
            animator.SetTrigger("TrRummage");
            if (rageTimer > randomTime + 5)
            {
                animator.ResetTrigger("TrRummage");
                animator.SetTrigger("TrRampage");
                Rage();
            }
        }
        
        if (timer > fireRate)
        {
            InstantiateProjectile();
            timer = 0;
        }

        timer += Time.deltaTime;
        rageTimer += Time.deltaTime;
    }

    private void InstantiateProjectile()
    {
        int randomGlassIndex = Random.Range(0, GlassBottles.Length);
        GameObject selectedGlassBottle = GlassBottles[randomGlassIndex];
        Instantiate(selectedGlassBottle, transform.position, transform.rotation);
    }

    private void FastMode()
    {
        if (fastMode > 4)
        {
            animator.SetTrigger("TrBartender");
            fireRate = 0.8f;

        }
        else if (fastMode <= 4)
        {
            animator.SetTrigger("TrBartenderFast");
            fireRate = 0.1f;
        }
    }

    void Rage()
    {
        
        Mode = true;
        fireRate = 0.08f;
        if (rageTimer > randomTime + 15)
        {
            
            fastMode = Random.Range(1, 10);
            Mode = false;
            rageTimer = 0;
        }
    }

}
