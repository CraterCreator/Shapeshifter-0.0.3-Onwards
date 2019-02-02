using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawner1 : MonoBehaviour
{
    public GameObject trail;
    public float speed;
    private GameObject left, right;
    private UI ui;

    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        StartCoroutine(SpawnTrail());
        speed = 0.25f;
        left = GameObject.Find("Triangle Left");
        right = GameObject.Find("Triangle Right");
    }

    void Update()
    {
        if (right.activeSelf == false || left.activeSelf == false)
        {
            speed = 0.25f;
        }
    }

    IEnumerator SpawnTrail()
    {
        for (int i = 0; i < i + 1; i++)
        {
            if (ui.mainMenu.activeSelf == false && ui.gameOver.activeSelf == false)
            {
                Instantiate(trail, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(speed);
        }

    }
}


