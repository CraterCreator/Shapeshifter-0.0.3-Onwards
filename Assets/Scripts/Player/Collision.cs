using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject particleL, particleR;
    public bool gameover;

    private UI ui;
    private TrailSpawner1 spawner, spawner2;
    private GameObject partic;
    private SpriteRenderer rend;
    private Collision collL, collR;
    private ParticleSystem syst;

    void Start()
    {
        rend = GameObject.Find("Right Neon").GetComponent<SpriteRenderer>();
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        spawner = GameObject.Find("Left").GetComponent<TrailSpawner1>();
        spawner2 = GameObject.Find("Right").GetComponent<TrailSpawner1>();
        collL = GameObject.Find("Triangle Left").GetComponent<Collision>();
        collR = GameObject.Find("Triangle Right").GetComponent<Collision>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Spike")
        {
            collL.gameover = true;
            collR.gameover = true;
            StartCoroutine(Die());
        }

        if (col.tag == "Checkpoint")
        {
            collL.partic = GameObject.Find("Particle");
            collR.partic = GameObject.Find("Particle");
            syst = partic.GetComponent<ParticleSystem>();
            var Main = syst.main;
            Main.startColor = rend.color;
            partic.SetActive(false);

            Destroy(col.transform.parent.gameObject);
            spawner.speed = 0.05f;
            spawner2.speed = 0.05f;
        }

        if (col.tag == "CheckpointFinish")
        {
            partic.SetActive(true);

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

    IEnumerator Die()
    {
        for (int i = 0; i < 1; i++)
        {
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            rend.color = new Color(255, 255, 255, 0);
            particleL.SetActive(true);
            particleR.SetActive(true);
            //Time.timeScale = Mathf.Lerp(1, 0, 100);
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
            particleL.SetActive(false);
            particleR.SetActive(false);
        }
    }
}