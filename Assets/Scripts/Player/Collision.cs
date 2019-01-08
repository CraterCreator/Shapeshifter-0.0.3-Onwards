using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public UI ui;
    private TrailSpawner spawner, spawner2;

    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        spawner = GameObject.Find("Left").GetComponent<TrailSpawner>();
        spawner2 = GameObject.Find("Right").GetComponent<TrailSpawner>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Spike")
        {
            gameObject.SetActive(false);
        }

        if (col.tag == "Checkpoint")
        {
            Destroy(col.transform.parent.gameObject);
            spawner.speed = 0.05f;
            spawner2.speed = 0.05f;
        }

        if (col.tag == "CheckpointFinish")
        {
            spawner.speed = 0.25f;
            spawner2.speed = 0.25f;
            StartCoroutine(AddPoints());
            Destroy(col.transform.parent.gameObject);
        }
    }

    IEnumerator AddPoints()
    {
        for (int i = 0; i < 10; i++)
        {
            ui.score++;
            yield return new WaitForSeconds(0.09f);
        }
    }
}