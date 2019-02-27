using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UI : MonoBehaviour
{
    private Animator anim;
    private Collision colL, colR;

    public bool scoreBool;
    public Spawner spawner;
    public Animator animOver, animBack, animScore;
    public GameObject left, right;
    public GameObject optionsMenu, mainMenu, gameOver, creditsMenu, manager, sfxTick, musicTick, scoreObj;
    public float monitor;
    public int score, highScore, deaths;
    public Text scoreUI, highUI, highUI2, menuScore;
    public AudioSource music, sfx;
    // Use this for initialization
    void Awake()
    {
        colL = GameObject.Find("Triangle Left").GetComponent<Collision>();
        colR = GameObject.Find("Triangle Right").GetComponent<Collision>();
        anim = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Animator>();
        highScore = PlayerPrefs.GetInt("Highscore");
        Advertisement.Initialize("3058067", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (colR.showAd == true || colL.showAd == true)
        {
            StartCoroutine(Ads());
        }

        if(scoreBool == true)
        {
            StartCoroutine(Add());
        }

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

        if (gameOver.activeSelf == true || mainMenu.activeSelf == true)
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
        scoreObj.SetActive(true);
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
        scoreObj.SetActive(true);
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
        deaths++;
    }
    IEnumerator Ads()
    {
        colR.showAd = false;
        colL.showAd = false;
        yield return new WaitForSeconds(0.6f);
        Advertisement.Show();
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(0.1f);
        score = 0;
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        manager.SetActive(true);
    }

    IEnumerator Add()
    {
        animScore.SetBool("Add", true);
        yield return new WaitForSeconds(0.2f);
        animScore.SetBool("Add", false);
        scoreBool = false;
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
            mainMenu.SetActive(false);
            creditsMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            creditsMenu.SetActive(false);
        }
    }

    public void SFX()
    {
        if (sfxTick.activeSelf == true)
        {
            sfxTick.SetActive(false);
            sfx.gameObject.SetActive(false);
        }
        else
        {
            sfxTick.SetActive(true);
            sfx.gameObject.SetActive(true);
        }
    }

    public void Music()
    {
        if (musicTick.activeSelf == true)
        {
            musicTick.SetActive(false);
            music.gameObject.SetActive(false);
        }
        else
        {
            musicTick.SetActive(true);
            music.gameObject.SetActive(true);
        }
    }

    void GameOver()
    {
        scoreObj.SetActive(false);
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
