using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private SpriteRenderer trail, triangle;
    // Use this for initialization
    void Start()
    {
        trail = gameObject.GetComponentInChildren<SpriteRenderer>();
        triangle = GameObject.Find("Triangle Right").GetComponent<SpriteRenderer>();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        trail.color = triangle.color;
        transform.Translate(0, -0.05f * Time.timeScale, 0, Space.World);
    }
}
