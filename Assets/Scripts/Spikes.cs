using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        moveSpeed = 0.0825f;
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -moveSpeed * Time.timeScale, 0);
    }
}
