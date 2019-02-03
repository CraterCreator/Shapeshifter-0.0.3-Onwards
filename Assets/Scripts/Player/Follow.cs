using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Collision col;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        col = GameObject.Find("Triangle Right").GetComponent<Collision>();

        if (name == "ParticleTransporterL")
        {
            player = GameObject.Find("Triangle Left");
        }

        if (name == "ParticleTransporterR")
        {
            player = GameObject.Find("Triangle Right");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (col.gameover == false)
        {
            gameObject.transform.position = player.transform.position;
        }
    }
}
