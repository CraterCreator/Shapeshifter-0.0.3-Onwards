using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Animator anim;

    public GameObject OptionsMenu, MainMenu;
    public float monitor;
    public float score;
    public Text scoreUI;
    // Use this for initialization
    void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Animator>();
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        monitor = Time.timeScale;
        scoreUI.text = "" + score;
    }

    IEnumerator SpeedUp()
    {
        for (int i = 0; i < i + 1; i++)
        {
            yield return new WaitForSeconds(1);
            if (Time.timeScale < 2)
            {
                Time.timeScale = Time.timeScale + 0.01f;
            }
        }
    }

    public void Play()
    {
        anim.SetBool("Play", true);
    }

    public void Options()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
}
