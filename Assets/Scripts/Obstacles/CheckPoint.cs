﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public float moveSpeed;
    private GameObject manager;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Game Manager");

        moveSpeed = 0.0825f;
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.activeSelf == false)
        {
            Destroy(gameObject);
        }

        transform.Translate(0, -moveSpeed * Time.timeScale, 0);
    }
}