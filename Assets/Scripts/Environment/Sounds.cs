using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    public AudioSource music, sfx;
    public AudioClip menuMusic, gameMusic, buttonUp, buttonDown, death, checkSplosion, point, miss, right, left, both;
    public Button play;
    public UI ui;
    public Collision col;

    void Update()
    {
        if(col.gameover == true && music.clip != menuMusic)
        {
            sfx.clip = death;
            sfx.Play();
            music.clip = menuMusic;
            music.PlayDelayed(1.3f);
        }
    }
}
