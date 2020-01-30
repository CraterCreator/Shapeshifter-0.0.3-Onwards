using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UI : MonoBehaviour
{
    public Animator anim;
    public Collision colL, colR;
    public Sounds sounds;
    public Button playButton;
    public bool scoreBool, credits;
    public Spawner spawner;
    public RuntimeAnimatorController mainAnim;
    public Animator animOver, animBack, animScore, animPlayer;
    public GameObject left, right, lPS, rPS;
    public GameObject mainMenu, manager, scoreObj;
    public int score, highScore, deaths;
    public Text scoreUI, highUI, menuScore;
    public AudioSource music, sfx;
    public Sprite sfxOn, sfxOff, musicOn, musicOff;
    public Image sfxImg, musicImg;

    // Use this for initialization
    void Awake()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        //Advertisement.Initialize("3058067", true);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("SFX") == 1)
        {
            sounds.sfx.mute = true;
            sfxImg.sprite = sfxOff;
        }

        if (PlayerPrefs.GetInt("SFX") == 0)
        {
            sounds.sfx.mute = false;
            sounds.sfx.clip = sounds.buttonUp;
            sounds.sfx.Play();
            sfxImg.sprite = sfxOn;
        }

        if (PlayerPrefs.GetInt("Music") == 1)
        {
            sounds.music.mute = true;
            sounds.sfx.clip = sounds.buttonUp;
            sounds.sfx.Play();
            musicImg.sprite = musicOff;
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            sounds.music.mute = false;
            sounds.sfx.clip = sounds.buttonDown;
            sounds.sfx.Play();
            musicImg.sprite = musicOn;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (colR.showAd == true || colL.showAd == true)
        {
            StartCoroutine(Ads());
        }

        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        menuScore.text = "" + score;
        scoreUI.text = "" + score;
        highUI.text = "" + highScore;

        if (colR.gameover || colL.gameover)
        {
            animBack.SetBool("Started", false);
            scoreObj.SetActive(false);
        }


        if (left.activeSelf == false || right.activeSelf == false)
        {
            GameOver();
        }

        if (mainMenu.activeSelf != true)
        {
            manager.SetActive(true);
            if (animOver.runtimeAnimatorController != mainAnim)
            {
                animOver.runtimeAnimatorController = mainAnim;
            }
        }
    }


    public void Play()
    {
        playButton.interactable = false;
        animBack.SetBool("Started", true);
        animPlayer.SetTrigger("Start");
        colL.gameover = false;
        colR.gameover = false;
        colL.edge.enabled = true;
        colR.edge.enabled = true;
        colR.gameover = false;
        colL.gameover = false;
        left.SetActive(true);
        lPS.SetActive(true);
        right.SetActive(true);
        rPS.SetActive(true);
        left.transform.localPosition = new Vector3(0, 0, 0);
        right.transform.localPosition = new Vector3(0, 0, 0);
        if (animOver.runtimeAnimatorController == mainAnim)
        {
            animOver.SetBool("Try", true);
        }
        else
        {
            animOver.SetBool("Play", true);
        }
        sounds.music.clip = sounds.gameMusic;
        sounds.music.Play();
        sounds.sfx.clip = sounds.buttonUp;
        sounds.sfx.Play();
        deaths++;
    }

    IEnumerator Ads()
    {
        colR.showAd = false;
        colL.showAd = false;
        yield return new WaitForSeconds(0.6f);
        //Advertisement.Show();
    }

    public void Credits()
    {
        if (credits == false)
        {
            sounds.sfx.clip = sounds.buttonUp;
            sounds.sfx.Play();
            credits = true;
            animOver.SetBool("Credits", true);
        }
        else
        {
            sounds.sfx.clip = sounds.buttonDown;
            sounds.sfx.Play();
            credits = false;
            animOver.SetBool("Credits", false);
        }
    }

    public void Rate()
    {
        Application.OpenURL("market://details?id=" + Application.productName);
    }

    public void SFX()
    {
        if (sfxImg.sprite == sfxOn)
        {
            sounds.sfx.mute = true;
            sfxImg.sprite = sfxOff;
            PlayerPrefs.SetInt("SFX", 1);
        }
        else
        {
            sounds.sfx.mute = false;
            sfxImg.sprite = sfxOn;
            PlayerPrefs.SetInt("SFX", 0);
        }
    }

    public void Music()
    {
        if (musicImg.sprite == musicOn)
        {
            sounds.music.mute = true;
            musicImg.sprite = musicOff;
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            sounds.music.mute = false;
            musicImg.sprite = musicOn;
            PlayerPrefs.SetInt("Music", 0);
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

    public void Off()
    {
        mainMenu.SetActive(false);
    }
}
