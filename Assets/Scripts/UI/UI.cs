﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Animator anim;

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
    }

    public void Play()
    {
        anim.SetBool("Play", true);
        animBack.SetBool("Started", true);
        StartCoroutine(Off());
    }

    public void TryAgain()
    {
        left.SetActive(true);
        right.SetActive(true);
        animOver.SetBool("Try", true);
        animBack.SetBool("Started", true);
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
        gameOver.SetActive(true);
        animBack.SetBool("Started", false);
        if (manager != null)
        {
            manager.SetActive(false);
        }
    }
}
