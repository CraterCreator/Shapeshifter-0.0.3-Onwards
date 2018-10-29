using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Animator anim;

    public Animator anim2;
    public GameObject left, right;
    public GameObject optionsMenu, mainMenu, gameOver, manager;
    public float monitor;
    public int score, highScore;
    public Text scoreUI, highUI, menuScore;
    // Use this for initialization
    void Awake()
    {
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

        switch (score)
        {
            case 10:
                Time.timeScale = 1.2f;
                break;
            case 20:
                Time.timeScale = 1.3f;
                break;
            case 30:
                Time.timeScale = 1.5f;
                break;
            case 40:
                Time.timeScale = 1.6f;
                break;
            case 50:
                Time.timeScale = 1.8f;
                break;
        }

        if (left.activeSelf == false || right.activeSelf == false)
        {
            GameOver();
        }
    }

    public void Play()
    {
        anim.SetBool("Play", true);
        StartCoroutine(Off());
    }

    public void TryAgain()
    {
        anim2.SetBool("Try", true);
        StartCoroutine(Off());
        score = 0;   
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(0.4f);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        manager.SetActive(true);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    void GameOver()
    {
        GameObject manager = GameObject.Find("Game Manager");
        Time.timeScale = 1;
        gameOver.SetActive(true);
        manager.SetActive(false);
        left.SetActive(true);
        right.SetActive(true);
    }
}
