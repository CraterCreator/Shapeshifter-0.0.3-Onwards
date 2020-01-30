using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool gameover, showAd;
    public EdgeCollider2D edge;
    public GameObject checkpointParticles, deathParticles;
    public int lastScore;
    public ColourSwap colorSwap;
    public UI ui;
    public Sounds sounds;
    public Collision collL, collR;
    public Animator playerAnim;


    void Awake()
    {
        gameover = true;
    }

    void Update()
    {
        if (gameover == true && ui.deaths > 0 && gameObject.activeSelf != false)
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

        if (ui.deaths == 4 && col.tag == "Spike")
        {
            showAd = true;
            ui.deaths = 1;
        }

        if (col.tag == "Holder")
        {
            Destroy(col.transform.parent.gameObject);
        }

        if (col.tag == "Checkpoint")
        {
            Destroy(col.gameObject);
        }

        if (col.tag == "CheckpointFinish")
        {
            if (gameObject.name == "Triangle Right")
            {
                GameObject aliveParticles = Instantiate(checkpointParticles, transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(aliveParticles, 1.5f);
                sounds.sfx.clip = sounds.checkSplosion;
                sounds.sfx.Play();
                Destroy(col.transform.gameObject);
                StartCoroutine(AddPoints());
            }
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
        playerAnim.SetTrigger("Dead");
        gameObject.SetActive(false);
        lastScore = ui.score;
        Time.timeScale = 1;
        edge.enabled = false;
        ui.mainMenu.SetActive(true);
        var main = deathParticles.GetComponent<ParticleSystem>().main;
        main.startColor = colorSwap.theColor;
        GameObject aliveParticles = Instantiate(deathParticles, transform.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(1.5f);
        Destroy(aliveParticles);
    }
}