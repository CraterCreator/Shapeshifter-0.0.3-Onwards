using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject particleL, particleR;
    public bool gameover, showAd;
    public EdgeCollider2D edge;
    public SpriteRenderer neonRend, rend;
    public int lastScore;

    private UI ui;
    private Sounds sounds;
    private TrailSpawner1 spawner, spawner2;
    private GameObject partic;
    private Collision collL, collR;
    private ParticleSystem syst;

    void Awake()
    {
        edge = GetComponent<EdgeCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        neonRend = GameObject.Find("Right Neon").GetComponent<SpriteRenderer>();
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        sounds = GameObject.Find("AudioController").GetComponent<Sounds>();
        spawner = GameObject.Find("Left").GetComponent<TrailSpawner1>();
        spawner2 = GameObject.Find("Right").GetComponent<TrailSpawner1>();
        collL = GameObject.Find("Triangle Left").GetComponent<Collision>();
        collR = GameObject.Find("Triangle Right").GetComponent<Collision>();
    }

    void Update()
    {
        if (gameover == true)
        {
            StartCoroutine(Die());
            Time.timeScale = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Spike")
        {
            collL.gameover = true;
            collR.gameover = true;
        }

        if (ui.deaths == 3 && col.tag == "Spike")
        {
            showAd = true;
            ui.deaths = 0;
        }

        if(col.tag == "Holder")
        {
            Destroy(col.transform.parent.gameObject);
        }

        if (col.tag == "Checkpoint")
        {
            StartCoroutine(CheckMyPoint());
            Destroy(col.transform.parent.gameObject);
            spawner.speed = 0.05f;
            spawner2.speed = 0.05f;
        }

        if (col.tag == "CheckpointFinish")
        {
            if (gameObject.name == "Triangle Right")
            {
                sounds.sfx.clip = sounds.checkSplosion;
                sounds.sfx.Play();
                Destroy(col.transform.parent.gameObject);
                partic.SetActive(true);

                spawner.speed = 0.25f;
                spawner2.speed = 0.25f;
                StartCoroutine(AddPoints());
            }

        }
    }

    IEnumerator CheckMyPoint()
    {
        collL.partic = GameObject.Find("Particle");
        collR.partic = GameObject.Find("Particle");
        yield return new WaitForSeconds(0.1f);
        syst = partic.GetComponent<ParticleSystem>();
        var Main = syst.main;
        Main.startColor = neonRend.color;

        partic.SetActive(false);

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
            lastScore = ui.score;
            Time.timeScale = 1;
            GameObject child = gameObject.transform.GetChild(0).gameObject;
            child.SetActive(false);
            edge.enabled = false;
            ui.mainMenu.SetActive(true);
            rend.enabled = false;
            particleL.SetActive(true);
            particleR.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
            particleL.SetActive(false);
            particleR.SetActive(false);
        }
    }
}