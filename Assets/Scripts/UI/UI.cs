using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UI : MonoBehaviour
{
    private Animator anim;
    private Collision colL, colR;

    public bool scoreBool, credits;
    public Spawner spawner;
    public RuntimeAnimatorController mainAnim;
    public Animator animOver, animBack, animScore;
    public GameObject left, right;
    public GameObject mainMenu, manager, scoreObj;
    public float monitor;
    public int score, highScore, deaths;
    public Text scoreUI, highUI, menuScore;
    public AudioSource music, sfx;
    public Sprite sfxOn, sfxOff, musicOn, musicOff;
    public Image sfxImg, musicImg;
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

        if (scoreBool == true)
        {
            StartCoroutine(Add());
        }

        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        monitor = Time.timeScale;
        menuScore.text = "" + score;
        scoreUI.text = "" + score;
        highUI.text = "" + highScore;

        if (left.activeSelf == false || right.activeSelf == false)
        {
            GameOver();
        }

        if (mainMenu.activeSelf == true)
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
        if (animOver.runtimeAnimatorController == mainAnim)
        {
            animOver.SetBool("Try", true);
        }
        else
        {
            animOver.SetBool("Play", true);
        }
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
        yield return new WaitForSeconds(0.5f);
        score = 0;
        mainMenu.SetActive(false);
        manager.SetActive(true);
        yield return new WaitForSeconds(1);
        if (animOver.runtimeAnimatorController != mainAnim)
        {
            animOver.runtimeAnimatorController = mainAnim;
        }
    }

    IEnumerator Add()
    {
        animScore.SetBool("Add", true);
        yield return new WaitForSeconds(0.2f);
        animScore.SetBool("Add", false);
        scoreBool = false;
    }

    public void Credits()
    {
        if (credits == false)
        {
            credits = true;
            animOver.SetBool("Credits", true);
        }
        else
        {
            credits = false;
            animOver.SetBool("Credits", false);
        }
    }

    public void SFX()
    {
        if (sfxImg.sprite == sfxOn)
        {
            sfxImg.sprite = sfxOff;
        }
        else
        {
            sfxImg.sprite = sfxOn;
        }
    }

    public void Music()
    {
        if (musicImg.sprite == musicOn)
        {
            musicImg.sprite = musicOff;
        }
        else
        {
            musicImg.sprite = musicOn;
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
