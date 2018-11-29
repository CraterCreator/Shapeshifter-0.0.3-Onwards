using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public UI ui;

    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
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
        }

        if (col.tag == "CheckpointFinish")
        {
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