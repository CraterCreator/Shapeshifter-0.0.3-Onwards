using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwap : MonoBehaviour
{
    private SpriteRenderer rend, colorRend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        colorRend = GameObject.Find("Right Neon").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.color = colorRend.color;
    }
}
