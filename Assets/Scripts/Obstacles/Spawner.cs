using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject[] Spikes;
    public GameObject menu;

    private bool off;
    private GameObject spike;
    private int index;

    public float spawnTime;

    // Use this for initialization
    void Start()
    {
        off = true;
        spawnTime = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.activeSelf == false && off == true)
        {
            StartCoroutine(Spawn());
            off = false;
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < i + 1; i++)
        {
            index = Random.Range(0, Spikes.Length);
            spike = Spikes[index];
            Instantiate(spike, spawnPos.position, spawnPos.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
