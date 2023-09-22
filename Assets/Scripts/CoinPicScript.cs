using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicScript : MonoBehaviour

{
    public TableScript tableScript;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> Sprites;
    public int rank;
    // Start is called before the first frame update
    void Start()
    {
        tableScript = GetComponentInParent<TableScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rank = tableScript.bumCount;
        if (rank == 0)
        {
            spriteRenderer.enabled = false;
        }
        else if (rank >=1 && rank <= 3)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = Sprites[rank];
        }
        
    }  
}
