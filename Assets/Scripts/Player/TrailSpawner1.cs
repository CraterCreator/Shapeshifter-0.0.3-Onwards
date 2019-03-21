using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawner1 : MonoBehaviour
{
    public GameObject trail;
    public float speed;
    private UI ui;
    private Collision col;

    void Start()
    {
        col = gameObject.transform.GetChild(0).GetComponent<Collision>();
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        StartCoroutine(SpawnTrail());
        speed = 0.25f;
    }

    void Update()
    {
        if(col.gameover == true)
        {
            speed = 0.25f;
        }

        if (col.gameover == false && speed != 0.05f)
        {
            speed = 0.25f;
        }
    }

    IEnumerator SpawnTrail()
    {
        for (int i = 0; i < i + 1; i++)
        {
            if (ui.mainMenu.activeSelf == false && ui.gameOver.activeSelf == false && col.gameover == false && ui.optionsMenu.activeSelf == false && ui.creditsMenu.activeSelf == false)
            {
                Instantiate(trail, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(speed);
        }
    }
}


