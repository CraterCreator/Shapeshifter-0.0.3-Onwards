using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Animator anim;
    private Collision colL, colR;

    public Spawner spawner;
    public Animator animOver, animBack;
    public GameObject left, right;
    public GameObject optionsMenu, mainMenu, gameOver, creditsMenu, manager, sfx, music;
    public float monitor;
    public int score, highScore;
    public Text scoreUI, highUI, highUI2, menuScore;
    // Use this for initialization
    void Awake()
    {
        colL = GameObject.Find("Triangle Left").GetComponent<Collision>();
        colR = GameObject.Find("Triangle Right").GetComponent<Collision>();
        anim = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Animator>();
        highScore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        menuScore.text = "" + score;
        monitor = Time.timeScale;
        scoreUI.text = "" + score;
        highUI.text = "" + highScore;
        highUI2.text = "" + highScore;

        if (left.activeSelf == false || right.activeSelf == false)
        {
            GameOver();
        }

        if(gameOver.activeSelf == true || mainMenu.activeSelf == true)
        {
            animBack.SetBool("Started", false);
        }
        else
        {
            animBack.SetBool("Started", true);
        }
    }

    public void Play()
    {
        colL.gameover = false;
        colR.gameover = false;
        colL.edge.enabled = true;
        colR.edge.enabled = true;
        left.SetActive(true);
        right.SetActive(true);
        anim.SetBool("Play", true);
        StartCoroutine(Off());
        score = 0;
    }

    public void TryAgain()
    {
        GameObject child1 = right.transform.GetChild(0).gameObject;
        GameObject child2 = left.transform.GetChild(0).gameObject;
        child1.SetActive(true);
        child2.SetActive(true);
        colL.gameover = false;
        colR.gameover = false;
        colL.edge.enabled = true;
        colR.edge.enabled = true;
        colL.rend.enabled = true;
        colR.rend.enabled = true;
        left.SetActive(true);
        right.SetActive(true);
        animOver.SetBool("Try", true);
        StartCoroutine(Off());
        score = 0;
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(0.1f);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        manager.SetActive(true);
    }

    public void Options()
    {
        if (optionsMenu.activeSelf == false)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }

    public void Credits()
    {
        if (creditsMenu.activeSelf == false)
        {
            creditsMenu.SetActive(true);
        }
        else
        {
            creditsMenu.SetActive(false);
        }
    }

    public void SFX()
    {
        if (sfx.activeSelf == true)
        {
            sfx.SetActive(false);
        }
        else
        {
            sfx.SetActive(true);
        }
    }

    public void Music()
    {
        if (music.activeSelf == true)
        {
            music.SetActive(false);
        }
        else
        {
            music.SetActive(true);
        }
    }

    void GameOver()
    {
        spawner.counter = 0;
        left.SetActive(false);
        right.SetActive(false);
        GameObject manager = GameObject.Find("Game Manager");
        Time.timeScale = 1;
        if (manager != null)
        {
            manager.SetActive(false);
        }
    }
}
