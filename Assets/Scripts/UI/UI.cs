using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Animator anim;
    private Spawner spawn;

    public GameObject OptionsMenu, MainMenu;
    public float monitor;
    public int score, highScore;
    public Text scoreUI, highUI, menuScore;
    // Use this for initialization
    void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Animator>();
        spawn = GameObject.Find("Game Manager").GetComponent<Spawner>();

        highScore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        monitor = Time.timeScale;
        scoreUI.text = "" + score;
        highUI.text = "" + highScore;

        switch (score)
        {
            case 10:
                Time.timeScale = 1.2f;
                spawn.spawnTime = 1.4f;
                break;
            case 20:
                Time.timeScale = 1.3f;
                spawn.spawnTime = 1.3f;
                break;
            case 30:
                Time.timeScale = 1.5f;
                spawn.spawnTime = 1.2f;
                break;
            case 40:
                Time.timeScale = 1.6f;
                spawn.spawnTime = 1.1f;
                break;
            case 50:
                Time.timeScale = 1.8f;
                spawn.spawnTime = 1;
                break;
        }
    }

    public void Play()
    {
        anim.SetBool("Play", true);
        StartCoroutine(Off());
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(0.4f);
        MainMenu.SetActive(false);

    }

    public void Options()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
}
