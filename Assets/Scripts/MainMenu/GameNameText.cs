using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameNameText : MonoBehaviour
{

    public TextMeshProUGUI title;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        title.fontSize = 200f + Mathf.Sin(Time.time) * 10f;
    }


    public void PlayButton()
    {

    }
}
