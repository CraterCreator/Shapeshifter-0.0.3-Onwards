using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public SpriteRenderer parent, child;

    // Use this for initialization
    void Start()
    {
        child = GetComponent<SpriteRenderer>();
        parent = transform.parent.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        child.color = parent.color;
    }
}
