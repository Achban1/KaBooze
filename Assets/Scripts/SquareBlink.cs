using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBlink : MonoBehaviour
{

    public Renderer Body;

    public Color startColor, endColor;
    float startTime;
    void Start()
    {
        // ... your other stuff 

        StartCoroutine(ChangeEngineColour());
    }

    private IEnumerator ChangeEngineColour()
    {
        float tick = 0f;
        while (Body.material.color != endColor)
        {
            tick += Time.deltaTime;
            Body.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));
            yield return null;
        }
    }
}
