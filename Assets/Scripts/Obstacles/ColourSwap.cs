using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSwap : MonoBehaviour
{
    private SpriteRenderer rend, colorRend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        colorRend = GameObject.Find("Right Neon").GetComponent<SpriteRenderer>();
        rend.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.color != Color.cyan && rend != null)
        {
            rend.color = colorRend.color;
        }
    }
}
